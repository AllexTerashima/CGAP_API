using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CGAP_API.Models;

namespace CGAP_API.Repository.Products
{
    public class ProductsRepository : IProductsRepository
    {

        ApplicationDbContext context;
        public ProductsRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Produto item)
        {
            context.Products.Add(item);
            context.SaveChanges();
        }

        public Produto Find(int id)
        {
            var item = context.Products.SingleOrDefault(p => p.ProdutoID == id);
            return item;
        }

        public IEnumerable<Produto> GetAll()
        {
            return context.Products.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Products.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Produto itemToUpdate, Produto item)
        {
            itemToUpdate.Marca = item.Marca;
            itemToUpdate.Tag = item.Tag;
            itemToUpdate.Tipo = item.Tipo;
            itemToUpdate.Valor = item.Valor;
            itemToUpdate.Sala = item.Sala;
            itemToUpdate.SalaID = item.SalaID;
            context.Products.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
