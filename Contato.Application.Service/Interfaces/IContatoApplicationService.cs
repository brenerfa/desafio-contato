using Contato.Application.Service.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contato.Application.Service
{
    public interface IContatoApplicationService
    {
        ContatoGetResponseMessage Get(string id);
        void Update(string id, ContatoUpdateRequest request);
        string Create(ContatoCreateRequest request);
        void Delete(string id);
        IEnumerable<ContatoResponse> List(int page, int size);
    }
}
