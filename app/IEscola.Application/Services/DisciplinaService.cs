using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace IEscola.Application.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        IDisciplinaRepository _repository;
        public DisciplinaService(IDisciplinaRepository repository)
        {
            _repository = repository;

        }

        public IEnumerable<Disciplina> Get()
        {
            var list = _repository.Get();
            return list;
        }

        void IDisciplinaService.Delete(Disciplina disciplina)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Disciplina> IDisciplinaService.Get()
        {
            throw new NotImplementedException();
        }

        Disciplina IDisciplinaService.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        void IDisciplinaService.Insert(Disciplina disciplina)
        {
            throw new NotImplementedException();
        }

        void IDisciplinaService.Update(Guid id, Disciplina disciplina)
        {
            throw new NotImplementedException();
        }
    }
}
