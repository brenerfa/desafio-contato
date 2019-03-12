using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contato.Application.Service;
using Contato.Application.Service.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contato.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/contato")]
    public class ContatoController : Controller
    {
        private readonly IContatoApplicationService contatoApplicationService;

        public ContatoController(IContatoApplicationService contatoApplicationService)
        {
            this.contatoApplicationService = contatoApplicationService;
        }

        [HttpGet]
        [Route("{idContato}")]
        public IActionResult Get(string idContato)
        {
            var response = contatoApplicationService.Get(idContato);
            if (response == null)
                return NotFound("Contato não encontrado.");
            else
                return Ok(response);
        }

        [HttpPut]
        [Route("{idContato}")]
        public IActionResult Update(string idContato, [FromBody] ContatoUpdateRequest request)
        {
            try
            {
                contatoApplicationService.Update(idContato, request);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] ContatoCreateRequest request)
        {
            string id = string.Empty;
            try
            {
                var validations = Validar(request);
                if (validations.Count > 0)
                    return BadRequest(validations.Select(v => new { atributo = v.Key, mensagem = v.Value }));

                id = contatoApplicationService.Create(request);

                return Created("", id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpDelete]
        [Route("{idContato}")]
        public IActionResult Delete(string idContato)
        {
            try
            {
                var response = contatoApplicationService.Get(idContato);
                if (response == null)
                    return NotFound("Contato não encontrado.");

                contatoApplicationService.Delete(idContato);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet]
        [Route("")]
        public IActionResult List([FromQuery] int page, [FromQuery] int size)
        {
            try
            {
                var response = contatoApplicationService.List(page, size);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private List<KeyValuePair<string, string>> Validar(ContatoCreateRequest request)
        {
            List<KeyValuePair<string, string>> validations = new List<KeyValuePair<string, string>>();
            if (String.IsNullOrEmpty(request.Canal))
                validations.Add(new KeyValuePair<string, string>("Canal", "Campo é obrigatório."));
            if (String.IsNullOrEmpty(request.Nome))
                validations.Add(new KeyValuePair<string, string>("Nome", "Campo é obrigatório."));
            if (String.IsNullOrEmpty(request.Valor))
                validations.Add(new KeyValuePair<string, string>("Valor", "Campo é obrigatório."));

            return validations;
        }
    }
}