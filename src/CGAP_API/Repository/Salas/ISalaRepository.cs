using CGAP_API.Models;
using System.Collections.Generic;

namespace CGAP_API.Repository.Salas
{
    public interface ISalaRepository
    {
        void Add(Sala item);
        IEnumerable<Sala> GetAll();
        Sala Find(int key);
        void Remove(int Id);
        void Update(Sala itemToUpdate, Sala item);
    }
}
