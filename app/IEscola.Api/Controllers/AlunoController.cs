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
            new Aluno(Guid.Parse("F58623A3-84A2-49C4-98DA-CC9E8B57F948"), "Joao", new DateTime(1984, 3, 20 ), 001),
            new Aluno(Guid.Parse("754691DB-5B8D-45D7-8AD6-DEBEC27077E1"), "Maria", new DateTime(1993, 7, 03 ), 002),
            new Aluno(Guid.Parse("7E643558-55BA-4EF5-9785-BCF0DBD8FA02"), "Rita", new DateTime(2000, 9, 20 ), 003),
            new Aluno(Guid.Parse("582CB327-DC56-4C13-8DB9-923FD7BBE8D3"), "Pedro", new DateTime(1997, 10, 05 ), 004),
        }; 

        // GET: api/<AlunoController>
        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            return Ok(alunoList);
        }

        // GET api/<AlunoController>
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            if (Guid.Empty == id)
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
