﻿using IEscola.Application.HttpObjects.Aluno.Response;
using IEscola.Application.HttpObjects.Disciplina.Response;
using IEscola.Application.HttpObjects.Professor.Request;
using IEscola.Application.HttpObjects.Professor.Response;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Application.Services
{
    public class ProfessorService : ServiceBase, IProfessorService
    {
        private readonly IProfessorRepository _repository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IAlunoRepository _alunoRepository;

        public ProfessorService(IProfessorRepository repository, INotificador notificador,
            IDisciplinaRepository disciplinaRepository,
            IAlunoRepository alunoRepository) : base(notificador)
        {
            _repository = repository;
            _disciplinaRepository = disciplinaRepository;
            _alunoRepository = alunoRepository;
        }



        public async Task<IEnumerable<ProfessorResponse>> GetAsync()
        {
            var list = await _repository.GetAsync();

            return list.Select(d => Map(d));
        }

        public async Task<ProfessorResponse> GetAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var professor = await _repository.GetAsync(id);

            if (professor is null)
            {
                NotificarErro("Professor não encontrado");
                return default;
            };

            // Retornar
            return Map(professor);
        }

        public async Task<ProfessorFullResponse> GetFullAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id inválido");
                return default;
            }

            var professor = await _repository.GetAsync(id);

            if (professor is null)
            {
                NotificarErro("Professor não encontrado");
                return default;
            };

            var tasks = new Task[]
            {
                Task.Run(async () => professor.Disciplina = await _disciplinaRepository.GetAsync(professor.DisciplinaId)),
                Task.Run(async () => professor.Alunos = await _alunoRepository.GetByProfessorIdAsync(id))
            };
            Task.WaitAll(tasks);

            // Retornar
            return MapFull(professor);
        }


        public async Task<ProfessorResponse> InsertAsync(ProfessorInsertRequest professorRequest)
        {
            /// Validar a professor
            if (string.IsNullOrWhiteSpace(professorRequest.Nome))
                NotificarErro("Nome não preenchido");

            // TODO: Validar o CPF
            if (string.IsNullOrWhiteSpace(professorRequest.Cpf))
                NotificarErro("Cpf não preenchido");

            // Professor deve ser maior que 18 ano
            if (professorRequest.DataNascimento >= DateTime.Today.AddYears(-18))
                NotificarErro("Data de nascimento inválida");

            if (TemNotificacao())
                return default;

            // Mapear para o objeto de domínio
            var id = Guid.NewGuid();
            var professor = new Professor(id, professorRequest.Nome, professorRequest.Cpf, 
                professorRequest.DataNascimento, professorRequest.DisciplinaId)
            {
                Tratamento = professorRequest.Tratamento,
                DataUtimaAlteracao = DateTime.UtcNow,
                UsuarioUtimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            // Processar
            await _repository.InsertAsync(professor);

            // Retornar
            return Map(professor);
        }



        public async Task<ProfessorResponse> UpdateAsync(ProfessorUpdateRequest professorRequest)
        {

            if (professorRequest.Id == Guid.Empty)
                NotificarErro("Id não preenchido");

            /// Validar a professor
            if (string.IsNullOrWhiteSpace(professorRequest.Nome))
                NotificarErro("Nome não preenchido");

            // TODO: Validar o CPF
            if (string.IsNullOrWhiteSpace(professorRequest.Cpf))
                NotificarErro("Cpf não preenchido");

            // Professor deve ser maior que 18 ano
            if (professorRequest.DataNascimento >= DateTime.Today.AddYears(-18))
                NotificarErro("Data de nascimento inválida");

            if (TemNotificacao())
                return default;

            // Validar se a disciplina do Id existe
            var disc = await GetAsync(professorRequest.Id);
            if (disc is null) return default;

            // Mapear para o objeto de domínio
            var professor = new Professor(professorRequest.Id, professorRequest.Nome, professorRequest.Cpf, 
                professorRequest.DataNascimento, professorRequest.DisciplinaId)
            {
                Tratamento = professorRequest.Tratamento,
                DataUtimaAlteracao = DateTime.UtcNow,
                UsuarioUtimaAlteracao = "antonio",
                UsuarioCadastro = "antonio"
            };

            if (professorRequest.Ativo)
                professor.Ativar();
            else
                professor.Inativar();

            // Processar
            await _repository.UpdateAsync(professor);

            // Retornar
            return Map(professor);
        }

        public async Task DeleteAsync(Guid id)
        {
            var professor = await _repository.GetAsync(id);

            if (professor is null)
            {
                NotificarErro("Professor não encontrado");
                return;
            }

            await _repository.DeleteAsync(professor);
        }

        #region Private Methods
        private static ProfessorResponse Map(Professor professor)
        {
            return new ProfessorResponse
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Cpf = professor.Cpf,
                DataNascimento = professor.DataNascimento,
                Tratamento = professor.Tratamento,
                Ativo = professor.Ativo
            };
        }
        private static ProfessorFullResponse MapFull(Professor professor)
        {
            return new ProfessorFullResponse
            {
                Id = professor.Id,
                Nome = professor.Nome,
                Cpf = professor.Cpf,
                DataNascimento = professor.DataNascimento,
                Tratamento = professor.Tratamento,
                Ativo = professor.Ativo,
                Disciplina = new DisciplinaResponse
                {
                    Id = professor.DisciplinaId,
                    Nome = professor.Disciplina.Nome,
                    Descricao = professor.Disciplina.Descricao,
                    Ativo = professor.Disciplina.Ativo
                },

                Alunos = professor.Alunos.Select(a => new AlunoResponse
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    NumeroMatricula = a.NumeroMatricula,
                    DataNascimento = a.DataNascimento,
                    ProfessorId = a.ProfessorId,
                    Ativo = a.Ativo
                })
            };
        }
        #endregion
    }
}
