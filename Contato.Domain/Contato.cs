using System;

namespace Contato.Domain
{
    public class Contato
    {
        public Contato(string nome, string canal, string valor, string observacao, string id = null)
        {
            Nome = nome;
            Canal = ConvertCanal(canal);
            Valor = valor;
            Observacao = observacao;
            if (String.IsNullOrEmpty(id))
                Id = Guid.NewGuid();
            else
                Id = Guid.Parse(id);
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Canal Canal { get; set; }
        public string Valor { get; set; }
        public string Observacao { get; set; }

        private Canal ConvertCanal(string canalDescription)
        {
            switch(canalDescription)
            {
                case "Email":
                    return Canal.Email;
                case "Fixo":
                    return Canal.Fixo;
                default:
                    return Canal.Celular;
            }
        }
    }
}
