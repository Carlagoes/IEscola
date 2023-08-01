using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscola.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly List<Endereco> _EnderecoList = new List<Endereco>
        {
            new Endereco("Rua teste", 153, "Gonzaga", "12345678", "Santos", "SP", Guid.Parse("9F119207-3ED2-41B2-AABA-B9D94FB43937"))
            

        };

        public async Task<IEnumerable<Endereco>> GetAsync()
        {
            return await Task.FromResult(_EnderecoList);
        }

        public async Task<Endereco> GetAsync(Guid professorId)
        {
            await Task.Delay(1_000);
            return await Task.FromResult(_EnderecoList.FirstOrDefault(d => d.ProfessorId == professorId));
        }

        public async Task InsertAsync(Endereco Endereco)
        {
            await Task.Run(() => _EnderecoList.Add(Endereco));
        }

        public async Task UpdateAsync(Endereco Endereco)
        {
            var disc = await GetAsync(Endereco.ProfessorId);

            await DeleteAsync(disc);

            await InsertAsync(Endereco);
        }

        public async Task DeleteAsync(Endereco Endereco)
        {
            await Task.Run(() => _EnderecoList.Remove(Endereco));
        }
    }
}
