using System;
using System.ComponentModel.DataAnnotations;

namespace IEscola.Application.HttpObjects.Endereco.Request
{
    public class EnderecoInsertRequest
    {
        [Required(ErrorMessage = "Endereço não preenchido.")]
        //[MinLength(4, ErrorMessage = "Endereço deve ter mais que 0 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Numero não preenchido.")]
        [Range(1, int.MaxValue, ErrorMessage = "Numero deve ser maior que 0")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Bairro não preenchido.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "CEP não preenchido.")]
        [Range(8, int.MaxValue, ErrorMessage = "CEP deve ter 8 números")]
        public string Cep { get; set; } //TIPO SER API


        [Required(ErrorMessage = "Cidade não preenchida.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado não preenchido.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "ProfessorId não preenchido.")]
        public Guid ProfessorId { get; set; }
        public bool Erro { get; set; }
    }
}
