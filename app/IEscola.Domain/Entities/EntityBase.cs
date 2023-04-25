using System;
using System.Collections.Generic;
using System.Text;

namespace IEscola.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataUtimaAlteracao { get; set; }
        public string UsuarioCadastro { get; set; }
        public string UsuarioUtimaAlteracao { get; set; }

        protected EntityBase()
        {
            DataCadastro = DateTime.Now;
            DataUtimaAlteracao = DateTime.Now;
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
