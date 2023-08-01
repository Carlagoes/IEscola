using IEscola.Application.HttpObjects.Endereco.Request;
using IEscola.Application.HttpObjects.Endereco.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEscola.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<IEnumerable<EnderecoResponse>> GetAsync();
        Task<EnderecoResponse> GetAsync(Guid ProfessorId);
        Task<EnderecoResponse> InsertAsync(EnderecoInsertRequest Endereco);
        Task<EnderecoResponse> UpdateAsync(EnderecoUpdateRequest Endereco);
        Task DeleteAsync(Guid id);

    }
}
