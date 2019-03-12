using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Contato.Application.Service.Messages
{
    [DataContract]
    public class ContatoUpdateRequest
    {
        [DataMember(Name = "nome")]
        public string Nome { get; set; }

        [DataMember(Name = "canal")]
        public string Canal { get; set; }

        [DataMember(Name = "valor")]
        public string Valor { get; set; }

        [DataMember(Name = "observacao")]
        public string Observacao { get; set; }
    }
}
