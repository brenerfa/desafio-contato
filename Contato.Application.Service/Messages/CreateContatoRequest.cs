using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Contato.Application.Service.Messages
{
    [DataContract]
    public class CreateContatoRequest
    {
        [DataMember(Name = "nome")]
        [Required(ErrorMessage = "nome obrigatorio")]
        public string Nome { get; set; }

        [DataMember(Name = "canal")]
        public string Canal { get; set; }

        [DataMember(Name = "valor")]
        public string Valor { get; set; }

        [DataMember(Name = "observacao")]
        public string Observacao { get; set; }
    }
}
