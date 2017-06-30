using CGAP.Domain.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGAP.Domain.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        ApplicationDbContext context;
        public ProdutosRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void Add(Produto item)
        {
            context.Produtos.Add(item);
            context.SaveChanges();
        }

        public Produto Find(int id)
        {
            var item = context.Produtos.SingleOrDefault(p => p.ProdutoID == id);
            return item;
        }

        public IEnumerable<Produto> GetAll()
        {
            return context.Produtos.ToList();
        }

        public void Remove(int Id)
        {
            var item = Find(Id);
            if (item != null)
            {
                context.Produtos.Remove(item);
                context.SaveChanges();
            }
        }

        public void Update(Produto itemToUpdate, Produto item)
        {
            itemToUpdate.Marca = item.Marca;
            itemToUpdate.Tag = item.Tag;
            itemToUpdate.Tipo = item.Tipo;
            itemToUpdate.Valor = item.Valor;
            //itemToUpdate.Sala = item.Sala;
            itemToUpdate.SalaID = item.SalaID;
            context.Produtos.Update(itemToUpdate);
            context.SaveChanges();
        }
    }
}
}
