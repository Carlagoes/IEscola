using IEscola.Application.HttpObjects.Aluno.Request;
using IEscola.Application.HttpObjects.Aluno.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Application.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoResponse>> Get();
        AlunoResponse Get(Guid id);
        AlunoResponse Insert(AlunoInsertRequest professor);
        AlunoResponse Update(AlunoUpdateRequest professor);
        void Delete(Guid id);

    }
}
