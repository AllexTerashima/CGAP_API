using CGAP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP.Domain.Repository.IRepository
{
    public class ISalaRepository
    {
        Task Add(Sala item);
        IEnumerable<Sala> GetAll();
        Sala Find(int key);
        void Remove(int Id);
        void Update(Sala itemToUpdate, Sala item);
    }
}
