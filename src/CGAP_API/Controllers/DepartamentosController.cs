using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CGAP_API.Repository.Departamentos;
using CGAP_API.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CGAP_API.Controllers
{
    [Route("api/[controller]")]
    public class DepartamentosController : Controller
    {

        public IDepartamentosRepository DepRepo { get; set; }

        public DepartamentosController(IDepartamentosRepository repo)
        {
            DepRepo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Departamento> GetAll()
        {
            return DepRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetDep")]
        public IActionResult GetById(int id)
        {
            var item = DepRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] Departamento item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            DepRepo.Add(item);

            return CreatedAtRoute("GetDep", new { Controller = "Departamentos", id = item.DepartamentoID}, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Departamento item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = DepRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            DepRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DepRepo.Remove(id);
        }
    }
}
