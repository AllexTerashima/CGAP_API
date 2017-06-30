using CGAP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP.Domain.Repository.IRepository
{
    public class IDepartamentoRepository
    {
        void Add(Departamento item);
        IEnumerable<Departamento> GetAll();
        Departamento Find(int key);
        void Remove(int Id);
        void Update(Departamento itemToUpdate, Departamento item);
    }
}
