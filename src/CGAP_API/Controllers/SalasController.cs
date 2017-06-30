using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CGAP_API.Repository.Salas;
using CGAP_API.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CGAP_API.Controllers
{
    [Route("api/[controller]")]
    public class SalasController : Controller
    {
        public ISalaRepository SalaRepo { get; set; }

        public SalasController(ISalaRepository repo)
        {
            SalaRepo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Sala> GetAll()
        {
            return SalaRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSalas")]
        public IActionResult Get(int id)
        {
            var item = SalaRepo.Find(id);

            if (item == null)
                return BadRequest();

            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Sala item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            await SalaRepo.Add(item);

            return CreatedAtRoute("GetSalas", new { controller = "Salas", id = item.SalaID}, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Sala item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = SalaRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            SalaRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SalaRepo.Remove(id);
        }
    }
}
