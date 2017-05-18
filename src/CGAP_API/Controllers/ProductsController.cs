using CGAP_API.Models;
using CGAP_API.Repository.Products;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CGAP_API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public IProductsRepository ProductsRepo { get; set; }

        public ProductsController(IProductsRepository _repo)
        {
            ProductsRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Produto> GetAll()
        {
            return ProductsRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetProducts")]
        public IActionResult GetById(int id)
        {
            var item = ProductsRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ProductsRepo.Add(item);
            return CreatedAtRoute("GetProducts", new { Controller = "Products", id = item.ProdutoID }, item);
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] Produto item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = ProductsRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            ProductsRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        [HttpPost("{id}")]
        public void Delete(int id)
        {
            ProductsRepo.Remove(id);
        }
    }
}
