using CGAP.Domain.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP.Domain.Repository
{
    public class UsuarioRepository : IUsuarioRepository
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
            itemToUpdate.Senha = item.Senha;
            itemToUpdate.ConfirmarSenha = item.ConfirmarSenha;
            //itemToUpdate.Departamento = item.Departamento;
            itemToUpdate.DepartamentoID = item.DepartamentoID;
            itemToUpdate.Nome = item.Nome;
            itemToUpdate.Telefone = item.Telefone;
            itemToUpdate.Auditorar = item.Auditorar;
            itemToUpdate.Emitir = item.Emitir;
            itemToUpdate.Receber = item.Receber;
            context.Usuarios.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
