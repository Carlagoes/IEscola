using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.HttpObjects.Disciplina.Response;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IEscola.Application.Services
{
    public class DisciplinaService : ServiceBase, IDisciplinaService
    {
        IDisciplinaRepository _repository;

        public DisciplinaService(IDisciplinaRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }

        public IEnumerable<DisciplinaResponse> Get()
        {
            var list = _repository.Get();
            return list.Select(d => Map(d));
            
        }

        public DisciplinaResponse Get(Guid id)
        {
            if (Guid.Empty == id)
            {
                NotificarErro("id invalido");
                return default;
            }

            var disciplina = _repository.Get(id);

            if(disciplina is null)
            {
                NotificarErro("Disciplina não encontrada");
                return default;
            };

            return Map(disciplina);
        }


        public DisciplinaResponse Insert(DisciplinaUpdateRequest disciplinaRequest)
        {
            //Validar a disciplina
            if(string.IsNullOrWhiteSpace(disciplinaRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (string.IsNullOrWhiteSpace(disciplinaRequest.Descricao))
                NotificarErro("Descricao não preenchido");

            if (TemNotificacao()) 
                return default;


            //Mapear para o objeto de dominio
            var id = Guid.NewGuid();
            var disciplina = new Disciplina(id, disciplinaRequest.Nome, disciplinaRequest.Descricao);
            disciplina.DataUtimaAlteracao = DateTime.UtcNow;
            disciplina.UsuarioUtimaAlteracao = "Antonio";
            disciplina.UsuarioCadastro = "Antonio";

            //Processar
            _repository.Insert(disciplina);

            //Retornar
            return Map(disciplina);
        }


        public DisciplinaResponse Update(DisciplinaUpdateRequest disciplinaRequest)
        {
            //Validar Disciplina
            if (disciplinaRequest.Id == Guid.Empty)
                NotificarErro("Id não preenchido");

            if (string.IsNullOrWhiteSpace(disciplinaRequest.Nome))
                NotificarErro("Nome não preenchido");

            if (string.IsNullOrWhiteSpace(disciplinaRequest.Descricao))
                NotificarErro("Descricao não preenchido");

            if (TemNotificacao())
                return default;

            //Validar se Disciplina do ID existe
            var disc = Get(disciplinaRequest.Id);
            if (disc is null) return default;

            var disciplina = new Disciplina(disciplinaRequest.Id, disciplinaRequest.Nome, disciplinaRequest.Descricao);
            disciplina.DataUtimaAlteracao = DateTime.UtcNow;
            disciplina.UsuarioUtimaAlteracao = "Antonio";
            disciplina.UsuarioCadastro = "Antonio";

            if (disciplinaRequest.Ativo)
                disciplina.Ativar();
            else
                disciplina.Inativar();

            _repository.Update(disciplina);

            return Map(disciplina);
        }

        public void Delete( Disciplina disciplina)
        {
            _repository.Delete(disciplina);
        }

        #region MetodosPrivados
        private static DisciplinaResponse Map(Disciplina disciplina)
        {
            return new DisciplinaResponse
            {
                Id = disciplina.Id,
                Nome = disciplina.Nome,
                Descricao = disciplina.Descricao,
                Ativo = disciplina.Ativo
            };
        }
        #endregion
    }
}
