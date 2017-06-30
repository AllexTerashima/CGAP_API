using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGAP_API.Models;
using Microsoft.Extensions.Options;
using Dapper;
using System.Data.SqlClient;

namespace CGAP_API.Repository.Salas
{
    public class SalaRepository : ISalaRepository
    {
        ApplicationDbContext context;
        private readonly CustomSettings _settings;

        public SalaRepository(IOptions<CustomSettings> settings, ApplicationDbContext _context)
        {
            _settings = settings.Value;
            context = _context;
        }

        public async Task Add(Sala item)
        {
            using (var db = new SqlConnection(_settings.ConnectionString))
            {
                var query = "INSET INTO dbo.Sala (SalaID, Nome, Tag, DepartamentoID) VALUES (@SalaID, @Nome, @Tag, @DepartamentoID)";
                var result = await db.ExecuteAsync(query, item);
            }           
        }

        public Sala Find(int id)
        {
            var item = context.Salas.SingleOrDefault(s => s.SalaID == id);
            return item;
        }

        public IEnumerable<Sala> GetAll()
        {
            return context.Salas.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Salas.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Sala itemToUpdate, Sala item)
        {
            itemToUpdate.Nome = item.Nome;
            itemToUpdate.Tag = item.Tag;
            itemToUpdate.DepartamentoID = item.DepartamentoID;
            //itemToUpdate.Departamento = item.Departamento;
            context.Salas.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
