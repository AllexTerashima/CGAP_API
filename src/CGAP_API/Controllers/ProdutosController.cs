using CGAP_API.Models;
using CGAP_API.Repository.Products;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CGAP_API.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        public IProdutosRepository ProdutosRepo { get; set; }

        public ProdutosController(IProdutosRepository _repo)
        {
            ProdutosRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Produto> GetAll()
        {
            return ProdutosRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetProducts")]
        public IActionResult GetById(int id)
        {
            var item = ProdutosRepo.Find(id);
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
            ProdutosRepo.Add(item);
            return CreatedAtRoute("GetProducts", new { Controller = "Products", id = item.ProdutoID }, item);
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] Produto item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = ProdutosRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            ProdutosRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        [HttpPost("{id}")]
        public void Delete(int id)
        {
            ProdutosRepo.Remove(id);
        }
    }
}
