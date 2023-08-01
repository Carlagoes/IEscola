using System;

namespace IEscola.Application.HttpObjects.Endereco.Response
{
    public class EnderecoResponse
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Erro { get; set; }
        
    }
}
