using IEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IEscola.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> GetAsync();
        Task<Endereco> GetAsync(Guid ProfessorId);
        Task InsertAsync(Endereco Endereco);
        Task UpdateAsync(Endereco Endereco);
        Task DeleteAsync(Endereco Endereco);
    }
}
