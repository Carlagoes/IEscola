using Microsoft.AspNetCore.Mvc;
using IEscola.Api.Filters;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using IEscola.Application.Interfaces;
using IEscola.Api.DefaultResponse;
using IEscola.Application.HttpObjects.Endereco.Response;
using IEscola.Application.HttpObjects.Endereco.Request;
using System.Threading.Tasks;
using IEscola.Infra.API;

namespace IEscola.Api.Controllers
{
    [Route("api/[controller]")]
    [AuthorizationActionFilterAsync]
    public class EnderecoController : MainController
    {
        private readonly IEnderecoService _service;


        public EnderecoController(IEnderecoService service, INotificador notificador) : base(notificador)
        {
            _service = service;
        }


        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<EnderecoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<ViaCepResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAsync ()
        {
            var list = await _service.GetAsync(); 

            return SimpleResponse(list);
        }

        [HttpGet("{id}")]
        //[ProducesResponseType(typeof(SimpleResponseObject<EnderecoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject<ViaCepResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
             var Endereco = await _service.GetAsync(id);

            return SimpleResponse(Endereco);
        }

        [HttpPost]
        //[ProducesResponseType(typeof(SimpleResponseObject<EnderecoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject<ViaCepResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PostAsync([FromBody] EnderecoInsertRequest Endereco)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);
            var response = await _service.InsertAsync(Endereco);

            return SimpleResponse(response);
        }

        [HttpPut()]
        //[ProducesResponseType(typeof(SimpleResponseObject<EnderecoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject<ViaCepResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> PutAsync([FromBody] EnderecoUpdateRequest Endereco)
        {
            if (!ModelState.IsValid) return SimpleResponse(ModelState);
            var response = await _service.UpdateAsync(Endereco);

            return SimpleResponse(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SimpleResponseObject), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);

            return SimpleResponse();
        }
    }
}
