using CGAP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP.Domain.Repository.IRepository
{
    public class IProdutoRepository
    {
        void Add(Produto item);
        IEnumerable<Produto> GetAll();
        Produto Find(int key);
        void Remove(int Id);
        void Update(Produto itemToUpdate, Produto item);
    }
}
