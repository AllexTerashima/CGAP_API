using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGAP_API.Models;
using CGAP_API.Settings;
using Microsoft.Extensions.Options;

namespace CGAP_API.Repository.Salas
{
    public class SalaRepository : ISalaRepository
    {
        ApplicationDbContext context;
        protected CustomSettings _settings;

        public SalaRepository(IOptions<CustomSettings> settings, ApplicationDbContext _context)
        {
            _settings = settings.Value;
            context = _context;
        }

        public void Add(Sala item)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Salas.Add(item);
                db.SaveChanges();
            }
        }

        public Sala Find(int id)
        {
            var item = context.Salas.SingleOrDefault(s => s.SalaID == id);
            return item;
        }

        public IEnumerable<Sala> GetAll()
        {
            /*List<Sala> dep = context.Salas.ToList();
            List<Sala> dep2 = new List<Sala>();
            foreach (var szinho in dep)
            {
                szinho.Departamento = null;
                dep2.Add(szinho);
            }
            return dep2;*/
            return context.Salas.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                //if (item.SalaProdutos == null)
                //{
                    context.Salas.Remove(item);
                    context.SaveChanges();
                //}
            }
        }

        public void Update(Sala itemToUpdate, Sala item)
        {
            //if (itemToUpdate.SalaProdutos == null)
            //{
                itemToUpdate.Nome = item.Nome;
                //itemToUpdate.SalaProdutos = item.SalaProdutos;
                itemToUpdate.Tag = item.Tag;
                itemToUpdate.DepartamentoID = item.DepartamentoID;
                //itemToUpdate.Departamento = item.Departamento;
                context.Salas.Update(itemToUpdate);
                context.SaveChanges();
            //}
        }
    }
}
