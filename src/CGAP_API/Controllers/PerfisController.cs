using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CGAP_API.Repository.Perfis;
using CGAP_API.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CGAP_API.Controllers
{
    [Route("api/[controller]")]
    public class PerfisController : Controller
    {

        public IPerfisRepository PerfisRepo { get; set; }

        public PerfisController(IPerfisRepository _PerfisRepo)
        {
            PerfisRepo = _PerfisRepo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Perfil> GetAll()
        {
            return PerfisRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetPerfis")]
        public IActionResult GetById(int id)
        {
            var item = PerfisRepo.Find(id);

            if(item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]Perfil item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            PerfisRepo.Add(item);

            return CreatedAtRoute("GetPerfis", new { Controller = "Perfis", id = item.PerfilID }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Perfil item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = PerfisRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            PerfisRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PerfisRepo.Remove(id);
        }
    }
}
