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
            context.Users.Add(item);
            context.SaveChanges();
        }

        public Usuario Find(string id)
        {
            var item = context.Users.SingleOrDefault(u => u.Id == id);
            return item;
        }

        public IEnumerable<Usuario> GetAll()
        {
            return context.Users.ToList();
        }

        public void Remove(string Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Users.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Usuario itemToUpdate, Usuario item)
        {
            itemToUpdate.Rg = item.Rg;
            itemToUpdate.Cpf = item.Cpf;
            itemToUpdate.Nascimento = item.Nascimento;
            itemToUpdate.Email = item.Email;
            //itemToUpdate.Password = item.Password;
            //itemToUpdate.ConfirmarSenha = item.ConfirmarSenha;
            //itemToUpdate.Departamento = item.Departamento;
            itemToUpdate.DepartamentoID = item.DepartamentoID;
            itemToUpdate.Nome = item.Nome;
            //itemToUpdate.Perfil = item.Perfil;
            itemToUpdate.PerfilID = item.PerfilID;
            itemToUpdate.PhoneNumber = item.PhoneNumber;
            context.Users.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
