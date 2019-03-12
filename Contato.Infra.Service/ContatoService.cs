using Contato.Domain;
using Contato.Domain.Repository;
using Contato.Domain.Service;
using System;
using System.Collections.Generic;

namespace Contato.Infra.Service
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            this.contatoRepository = contatoRepository;
        }

        public void Create(Domain.Contato contato)
        {
            contatoRepository.Create(contato);
        }

        public void Delete(Guid id)
        {
            contatoRepository.Delete(id);
        }

        public Contato.Domain.Contato Get(Guid id)
        {
            return contatoRepository.Get(id);
        }

        public IEnumerable<Contato.Domain.Contato> List(int page, int size)
        {
            return contatoRepository.List(page, size);
        }

        public void Update(Contato.Domain.Contato contato)
        {
            contatoRepository.Update(contato);
        }
    }
}
