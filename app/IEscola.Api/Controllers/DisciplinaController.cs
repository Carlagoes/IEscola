﻿using Microsoft.AspNetCore.Mvc;
using IEscola.Api.Filters;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using IEscola.Application.Interfaces;
using IEscola.Api.DefaultResponse;
using IEscola.Application.HttpObjects.Disciplina.Response;
using IEscola.Application.HttpObjects.Disciplina.Request;

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [AuthorizationActionFilterAsync]
    public class DisciplinaController : MainController
    {
        private readonly IDisciplinaService _service;


        public DisciplinaController(IDisciplinaService service, INotificador notificador) : base(notificador)
        {
            _service = service;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DisciplinaResponse>), StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            var list = _service.Get();

            return SimpleResponse(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        public ActionResult Get(Guid id)
        {
             var disciplina = _service.Get(id);

            return SimpleResponse(disciplina);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SimpleResponseObject<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] DisciplinaInsertRequest disciplina)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);
            var response = _service.Insert(disciplina);

            return SimpleResponse(response);
        }

        [HttpPut()]
        [ProducesResponseType(typeof(SimpleResponseObject<DisciplinaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] DisciplinaUpdateRequest disciplina)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);
            var response = _service.Update(disciplina);

            return SimpleResponse(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        { 
            _service.Delete(id);

            return SimpleResponse();
        }
    }
}
