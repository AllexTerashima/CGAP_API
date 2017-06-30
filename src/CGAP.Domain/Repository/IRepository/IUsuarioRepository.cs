using CGAP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP.Domain.Repository.IRepository
{
    public class IUsuarioRepository
    {
        void Add(Usuario item);
        IEnumerable<Usuario> GetAll();
        Usuario Find(int key);
        void Remove(int Id);
        void Update(Usuario itemToUpdate, Usuario item);
    }
}
