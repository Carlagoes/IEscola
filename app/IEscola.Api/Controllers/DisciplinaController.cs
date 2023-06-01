using IEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using IEscola.Application.Interfaces;
using IEscola.Api.DefaultResponse;

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    public class DisciplinaController : MainController
    {
        private readonly IDisciplinaService _service;
        private readonly INotificador _notificador;


        public DisciplinaController(IDisciplinaService service, INotificador notificador) : base(notificador)
        {
            _service = service;
            _notificador = notificador;
        }


        // GET: api/<DisciplinaController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Disciplina>), StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            var list = _service.Get();

            return SimpleResponse(list);
        }

        // GET api/<DisciplinaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject<Disciplina>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        public ActionResult Get(Guid id)
        {
            if ( Guid.Empty  == id)
            {
                NotificarErro("id inválido");
                return SimpleResponse();
            }

            
            var disciplina = _service.Get(id);

            return SimpleResponse();
        }

        // POST api/<DisciplinaController>/5
        [HttpPost]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Disciplina disciplina)
        {
            _service.Insert(disciplina);

            return SimpleResponse(disciplina);
        }

        // PUT api/<DisciplinaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Put(Guid id, [FromBody] Disciplina disciplina)
        {
            _service.Update(id, disciplina);

            return SimpleResponse(disciplina);
        }

        // DELETE api/<DisciplinaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        {
            var disciplina = _service.Get(id);

            _service.Delete(disciplina);

            return SimpleResponse();
        }
    }
}
