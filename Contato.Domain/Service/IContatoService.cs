using System;
using System.Collections.Generic;
using System.Text;

namespace Contato.Domain.Service
{
    public interface IContatoService
    {
        void Create(Contato contato);
        Contato Get(Guid id);
        void Update(Contato contato);
        void Delete(Guid id);
        IEnumerable<Contato> List(int page, int size);
    }
}
