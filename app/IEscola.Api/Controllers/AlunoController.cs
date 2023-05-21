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
    public class AlunoController : ControllerBase
    {
        private List<Aluno> alunoList = new List<Aluno>
        {
            new Aluno(1, "Joao", new DateTime(1984, 3, 20 ), 001),
            new Aluno(2, "Maria", new DateTime(1993, 7, 03 ), 002),
            new Aluno(3, "Rita", new DateTime(2000, 9, 20 ), 003),
            new Aluno(4, "Pedro", new DateTime(1997, 10, 05 ), 004),
        }; 

        // GET: api/<AlunoController>
        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            return Ok(alunoList);
        }

        // GET api/<AlunoController>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("id deve ser maior que zero");
            
            var aluno = alunoList.FirstOrDefault(p => p.Id == id);

            return Ok(aluno);
        }

        // POST api/<AlunoController>/5
        [HttpPost]
        public IActionResult Post([FromBody] Aluno aluno)
        {
            return Ok();
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Aluno aluno)
        {
            return Ok();
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
