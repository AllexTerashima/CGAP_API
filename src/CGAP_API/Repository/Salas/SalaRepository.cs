using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGAP_API.Models;

namespace CGAP_API.Repository.Salas
{
    public class SalaRepository : ISalaRepository
    {
        ApplicationDbContext context;

        public SalaRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Sala item)
        {
            context.Add(item);
            context.SaveChanges();
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
