using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGAP_API.Models;

namespace CGAP_API.Repository.Perfis
{
    public class PerfisRepository : IPerfisRepository
    {

        public ApplicationDbContext context;

        public PerfisRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Perfil item)
        {
            context.Perfis.Add(item);
            context.SaveChanges();
        }

        public Perfil Find(int id)
        {
            var item = context.Perfis.SingleOrDefault(p => p.PerfilID == id);
            return item;
        }

        public IEnumerable<Perfil> GetAll()
        {
            return context.Perfis.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Perfis.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Perfil itemToUpdate, Perfil item)
        {
            itemToUpdate.Auditorar = item.Auditorar;
            itemToUpdate.Emitir = item.Emitir;
            itemToUpdate.Nome = item.Nome;
            itemToUpdate.Receber = item.Receber;
            itemToUpdate.PerfilUsuarios = item.PerfilUsuarios;
            context.Perfis.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
