using CGAP_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CGAP_API.Repository.Usuarios
{
    public interface IUsuariosRepository
    {
        Task Add(Usuario item);
        IEnumerable<Usuario> GetAll();
        Task<Usuario> Find(string id);
        Task Remove(string Id);
        Task Update(Usuario itemToUpdate, Usuario item);
    }
}
