using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscola.Infra.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly List<Professor> _professorList = new List<Professor>
        {
            new Professor(Guid.Parse("9F119207-3ED2-41B2-AABA-B9D94FB43937"), "Antonio", "123456", new DateTime(1990, 2, 27), Guid.Parse("292499B0-2B09-4787-92CF-8C352456EAE0")),
            new Professor(Guid.Parse("6060BFC6-6311-473E-827E-FFD7C9A7B260"), "Maria", "123444", new DateTime(1993, 3, 11), Guid.Parse("292499B0-2B09-4787-92CF-8C352456EAE0")),
            new Professor(Guid.Parse("C3C8AD06-B623-4FD6-8A93-0DCDCA9E0BE4"), "João", "133356", new DateTime(1984, 4, 13), Guid.Parse("FF829D06-A51E-413A-A800-8DA041F60AA6")),
            new Professor(Guid.Parse("4085FD30-3B97-4482-B189-E045FD309AD0"), "Luis", "111456", new DateTime(1983, 5, 07), Guid.Parse("FF829D06-A51E-413A-A800-8DA041F60AA6")),
            new Professor(Guid.Parse("465BCF15-6D8E-4DC6-8ECB-E61D56713DBC"), "Rose", "122226", new DateTime(1998, 6, 03), Guid.Parse("292499B0-2B09-4787-92CF-8C352456EAE0")),
            new Professor(Guid.Parse("465BCF15-6D8E-4DC6-8ECB-E61D56713DBC"), "Rose", "122226", new DateTime(1998, 6, 03), Guid.Parse("292499B0-2B09-4787-92CF-8C352456EAE0")),
        };

        public async Task<IEnumerable<Professor>> GetAsync()
        {
            return await Task.FromResult(_professorList);
        }

        public async Task<Professor> GetAsync(Guid id)
        {
            return await Task.FromResult(_professorList.FirstOrDefault(d => d.Id == id));
        }

        public async Task InsertAsync(Professor professor)
        {
            await Task.Run(() => _professorList.Add(professor));
        }

        public async Task UpdateAsync(Professor professor)
        {
            var prof = await GetAsync(professor.Id);
            await DeleteAsync(prof);
            await InsertAsync(professor);
        }

        public async Task DeleteAsync(Professor professor)
        {
            await Task.Run(() => _professorList.Remove(professor));
        }
    }
}
