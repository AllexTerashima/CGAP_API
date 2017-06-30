using CGAP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_API.Repository.Departamentos
{
    public interface IDepartamentosRepository
    {
        void Add(Departamento item);
        IEnumerable<Departamento> GetAll();
        Departamento Find(int key);
        void Remove(int Id);
        void Update(Departamento itemToUpdate, Departamento item);
    }
}