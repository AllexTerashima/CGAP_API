using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CGAP_API.Repository.Usuarios;
using CGAP_API.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CGAP_API.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        public IUsuariosRepository UsuariosRepo { get; set; }

        public UsuariosController(IUsuariosRepository _UsuariosRepo)
        {
            UsuariosRepo = _UsuariosRepo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return UsuariosRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUsuarios")]
        public IActionResult GetById(string id)
        {
            var item = UsuariosRepo.Find(id);
            if(item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]Usuario item)
        {
            if(item == null)
            {
                return BadRequest();
            }
               UsuariosRepo.Add(item);
return CreatedAtRoute("GetUsuarios", new { Controller = "Usuarios", id = item.Id }, item);
           
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Usuario item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var itemToUpdate = UsuariosRepo.Find(id);
            if (itemToUpdate == null)
            {
                return NotFound();
            }
            UsuariosRepo.Update(itemToUpdate, item);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpPost("{id}")]
        public void Delete(string id)
        {
            UsuariosRepo.Remove(id);
        }
    }
}
