using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGAP_API.Models;

namespace CGAP_API.Repository.Departamentos
{
    public class DepartamentoRepository : IDepartamentosRepository
    {
        ApplicationDbContext context;

        public DepartamentoRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Departamento item)
        {
            context.Add(item);
            context.SaveChanges();
        }

        public Departamento Find(int id)
        {
            var item = context.Departamentos.SingleOrDefault(d => d.DepartamentoID == id);
            return item;
        }

        public IEnumerable<Departamento> GetAll()
        {
            return context.Departamentos.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Departamentos.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Departamento itemToUpdate, Departamento item)
        {
            itemToUpdate.Nome = item.Nome;
            itemToUpdate.Pais = item.Pais;
            itemToUpdate.Estado = item.Estado;
            itemToUpdate.Cidade = item.Cidade;
            context.Departamentos.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
