using CGAP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP_API.Repository.Perfis
{
    public interface IPerfisRepository
    {
        void Add(Perfil item);
        IEnumerable<Perfil> GetAll();
        Perfil Find(int key);
        void Remove(int Id);
        void Update(Perfil itemToUpdate, Perfil item);
    }
}
