﻿using System;
using System.Collections.Generic;

namespace IEscola.Domain.Entities
{
    public class Professor : EntityBase
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Endereco { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public IEnumerable<Aluno> Alunos { get; set; }
        public Guid DisciplinaId { get; private set; }
        public Disciplina Disciplina { get; set; }
        public string Tratamento { get; set; }



        public Professor(Guid id, string nome, string cpf, DateTime? dataNascimento, Guid disciplinaId)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            DisciplinaId = disciplinaId;
        }

    }
}
