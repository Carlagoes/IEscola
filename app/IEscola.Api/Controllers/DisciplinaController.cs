using IEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using IEscola.Infra.Repositories;

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        

        // GET: api/<DisciplinaController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Disciplina>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Disciplina>> Get()
        {
            var repository = new DisciplinaRepository();
            var list = repository.Get();

            return Ok(list);
        }

        // GET api/<DisciplinaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Disciplina>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult Get(Guid id)
        {
            if ( Guid.Empty  == id)
                return BadRequest("id invalido");

            var repository = new DisciplinaRepository();
            var disciplina = repository.Get(id);

            return Ok(disciplina);
        }

        // POST api/<DisciplinaController>/5
        [HttpPost]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Disciplina disciplina)
        {
            var repository = new DisciplinaRepository();
            repository.Insert(disciplina);

            return Ok(disciplina);
        }

        // PUT api/<DisciplinaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Put(Guid id, [FromBody] Disciplina disciplina)
        {
            var repository = new DisciplinaRepository();
            repository.Update(id, disciplina);

            return Ok(disciplina);
        }

        // DELETE api/<DisciplinaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        {
            var repository = new DisciplinaRepository();
            var disciplina = repository.Get(id);

            repository.Delete(disciplina);

            return Ok();
        }
    }
}
