﻿using IEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using IEscola.Infra.Repositories;
using IEscola.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    public class DisciplinaController : MainController
    {
        private readonly IDisciplinaService _service;

        public DisciplinaController(IDisciplinaService service)
        {
            _service = service;
        }


        // GET: api/<DisciplinaController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Disciplina>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Disciplina>> Get()
        {
            var list = _service.Get();

            return Ok(list);
        }

        // GET api/<DisciplinaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult Get(Guid id)
        {
            if ( Guid.Empty  == id)
                return BadRequest("id invalido");

            
            var disciplina = _service.Get(id);

            return Ok(disciplina);
        }

        // POST api/<DisciplinaController>/5
        [HttpPost]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Disciplina disciplina, [FromHeader, Required] DadosLigacao dadosLigacao)
        {
            _service.Insert(disciplina);

            return Ok(disciplina);
        }

        // PUT api/<DisciplinaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Disciplina), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Put(Guid id, [FromBody] Disciplina disciplina)
        {
            _service.Update(id, disciplina);

            return Ok(disciplina);
        }

        // DELETE api/<DisciplinaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        {
            var disciplina = _service.Get(id);

            _service.Delete(disciplina);

            return Ok();
        }
    }
}
