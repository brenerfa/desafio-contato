using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Contato.Application.Service.Messages
{
    public class ContatoResponse : ContatoMessage
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}
