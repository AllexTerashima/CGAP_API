using CGAP_API.Models;
using System.Collections.Generic;

namespace CGAP_API.Repository.Usuarios
{
    public interface IUsuariosRepository
    {
        void Add(Usuario item);
        IEnumerable<Usuario> GetAll();
        Usuario Find(string key);
        void Remove(string Id);
        void Update(Usuario itemToUpdate, Usuario item);
    }
}
