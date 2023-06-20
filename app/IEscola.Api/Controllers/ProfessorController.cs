using IEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using IEscola.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    
    public class ProfessorController : MainController
    {
        private List<Professor> professorList = new List<Professor>
        {
            new Professor(Guid.Parse("91DA7AD7-08DD-4EF0-917F-13DE7DBA690E"), "Antonio", "12345678911", new DateTime(1990, 2, 27 )),
            new Professor(Guid.Parse("F602AD3F-91A1-45A9-8D14-CBF77EEDAF38"), "José", "12345678922", new DateTime(1985, 2, 21 )),
            new Professor(Guid.Parse("A165B4F0-CEE2-4647-8C13-A2E0ABB0B906"), "João", "22245678933", new DateTime(1983, 12, 31 )),
            new Professor(Guid.Parse("470D8DE8-7152-45FD-BFE1-28A5C01D6092"), "Maria", "44345678944", new DateTime(1989, 3, 15 ))
        };

        public ProfessorController(INotificador notificador) : base(notificador)
        {

        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            return Ok(professorList);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        //[ProducesResponseType(IEnumerable<Professor>, StatusCode = 200)]
        public ActionResult Get(Guid id)
        {
            if (Guid.Empty == id)
                return BadRequest("id deve ser maior que zero");
            
            var professor = professorList.FirstOrDefault(p => p.Id == id);

            //Constants
            if (professor != null) 
                professor.Tratamento = Constantes.TratamentoProfessor;


            return Ok(professor);
        }

        // POST api/<ProfessorController>/5
        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {
            return Ok();
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Professor professor)
        {
            return Ok();
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
