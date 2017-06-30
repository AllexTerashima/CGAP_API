using CGAP_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CGAP_API.Repository.Salas
{
    public interface ISalaRepository
    {
        Task Add(Sala item);
        IEnumerable<Sala> GetAll();
        Sala Find(int key);
        void Remove(int Id);
        void Update(Sala itemToUpdate, Sala item);
    }
}
