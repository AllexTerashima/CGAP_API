using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGAP_API.Models;
using System.IO;

namespace CGAP_API.Repository.Usuarios
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public ApplicationDbContext context;

        public UsuariosRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Usuario item)
        {
            context.Usuarios.Add(item);
            context.SaveChanges();
        }

        public Usuario Find(int id)
        {
            var item = context.Usuarios.SingleOrDefault(u => u.UsuarioID == id);
            return item;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return context.Usuarios.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Usuarios.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Usuario itemToUpdate, Usuario item)
        {
            itemToUpdate.Rg = item.Rg;
            itemToUpdate.Cpf = item.Cpf;
            itemToUpdate.Nascimento = item.Nascimento;
            itemToUpdate.Email = item.Email;
            itemToUpdate.Departamento = item.Departamento;
            itemToUpdate.DepartamentoID = item.DepartamentoID;
            itemToUpdate.Nome = item.Nome;
            itemToUpdate.Perfil = item.Perfil;
            itemToUpdate.PerfilID = item.PerfilID;
            itemToUpdate.Telefone = item.Telefone;
            context.Usuarios.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
