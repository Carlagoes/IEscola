using System;

namespace IEscola.Domain.Entities
{
    public class Disciplina : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Disciplina(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }


        
    }
    
}
