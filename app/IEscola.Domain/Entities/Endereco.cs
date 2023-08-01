using System;

namespace IEscola.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public bool Erro { get; set; }
        public Guid ProfessorId { get; private set; }
        public Professor Professor { get; set; }


        public Endereco(string logradouro, int numero, string bairro,
            string cep, string cidade, string uF, Guid professorId)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            UF = uF;
            ProfessorId = professorId;
        }

        public void CepInvalido()
        {
            Erro = false;
        }

        public void CepValido()
        {
            Erro = true;
        }




    }
    
}
