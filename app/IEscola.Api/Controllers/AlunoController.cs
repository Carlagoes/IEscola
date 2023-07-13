using IEscola.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using IEscola.Api.Filters;
using IEscola.Application.Interfaces;
using IEscola.Api.DefaultResponse;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using IEscola.Application.HttpObjects.Aluno.Response;
using IEscola.Application.HttpObjects.Aluno.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [AuthorizationActionFilterAsync]
    public class AlunoController : MainController
    {
        private readonly IAlunoService _service;

        public AlunoController(INotificador notificador, IAlunoService service) : base(notificador)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SimpleResponseObject<IEnumerable<AlunoResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var list = await _service.Get();
            return SimpleResponse(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SimpleResponseObject<AlunoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        public ActionResult Get(Guid id)
        {
            if (Guid.Empty == id)
                return BadRequest("id inválido");
            
            var aluno = _service.Get(id);

            return SimpleResponse(aluno);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SimpleResponseObject<AlunoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] AlunoInsertRequest aluno)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = _service.Insert(aluno);

            return SimpleResponse(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(SimpleResponseObject<AlunoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] AlunoUpdateRequest aluno)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);

            var response = _service.Update(aluno);

            return SimpleResponse(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);

            return SimpleResponse();
        }

        
    }
}
