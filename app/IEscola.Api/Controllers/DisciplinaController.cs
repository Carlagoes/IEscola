using IEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private List<Disciplina> disciplinaList = new List<Disciplina>
        {
            new Disciplina("Português"),
            new Disciplina("Matemática"),
            new Disciplina("Geografia"),
            new Disciplina("Ciências")
        }; 

        // GET: api/<DisciplinaController>
        [HttpGet]
        public ActionResult<IEnumerable<Disciplina>> Get()
        {
            return Ok(disciplinaList);
        }

        // GET api/<DisciplinaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("id deve ser maior que zero");
            
            var disciplina = disciplinaList.FirstOrDefault(p => p.Id == id);

            return Ok(disciplina);
        }

        // POST api/<DisciplinaController>/5
        [HttpPost]
        public IActionResult Post([FromBody] Disciplina disciplina)
        {
            return Ok();
        }

        // PUT api/<DisciplinaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Disciplina disciplina)
        {
            return Ok();
        }

        // DELETE api/<DisciplinaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
