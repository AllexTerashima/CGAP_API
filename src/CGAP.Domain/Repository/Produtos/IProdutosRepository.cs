using CGAP_API.Models;
using System.Collections.Generic;

namespace CGAP_API.Repository.Products
{
    public interface IProdutosRepository
    {
        void Add(Produto item);
        IEnumerable<Produto> GetAll();
        Produto Find(int key);
        void Remove(int Id);
        void Update(Produto itemToUpdate, Produto item);
    }
}
