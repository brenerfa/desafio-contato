using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Contato.Application.Service.Messages;
using Contato.Domain;
using Contato.Domain.Service;
using Newtonsoft.Json;

namespace Contato.Application.Service
{
    public class ContatoApplicationService : IContatoApplicationService
    {
        private readonly IContatoService contatoService;

        public ContatoApplicationService(IContatoService contatoService)
        {
            this.contatoService = contatoService;
        }

        public ContatoGetResponseMessage Get(string id)
        {
            var contato = contatoService.Get(Guid.Parse(id));

            ContatoGetResponseMessage response = null;
            if(contato != null)
            {
                response = new ContatoGetResponseMessage();
                response.Canal = contato.Canal.ToString();
                response.Id = contato.Id;
                response.Nome = contato.Nome;
                response.Observacao = contato.Observacao;
                response.Valor = contato.Valor;
            }

            return response;
        }

        public void Update(string id, ContatoUpdateRequest request)
        {
            Domain.Contato entity = new Domain.Contato(request.Nome, request.Canal, request.Valor, request.Observacao, id);
            contatoService.Update(entity);
        }

        public string Create(ContatoCreateRequest request)
        {
            Domain.Contato entity = new Domain.Contato(request.Nome, request.Canal, request.Valor, request.Observacao);
            contatoService.Create(entity);

            return entity.Id.ToString();
        }

        public void Delete(string id)
        {
            contatoService.Delete(Guid.Parse(id));
        }

        public IEnumerable<ContatoResponse> List(int page, int size)
        {
            var contatos = contatoService.List(page, size);
            List<ContatoResponse> response = contatos.Select(c => new ContatoResponse()
            {
                Id = c.Id.ToString(),
                Canal = c.Canal.ToString(),
                Nome = c.Nome,
                Observacao = c.Observacao,
                Valor = c.Valor
            }).ToList();

            return response;
        }
    }
}
