using IEscola.Application.HttpObjects.Disciplina.Request;
using IEscola.Application.HttpObjects.Disciplina.Response;
using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IEscola.Application.Interfaces
{
    public interface IDisciplinaService
    {
        IEnumerable<DisciplinaResponse> Get();
        DisciplinaResponse Get(Guid id);
        DisciplinaResponse Insert(DisciplinaInsertRequest disciplinaRequest);
        DisciplinaResponse Update(DisciplinaUpdateRequest disciplinaRequest);
        void Delete(Disciplina disciplina);

    }
}
