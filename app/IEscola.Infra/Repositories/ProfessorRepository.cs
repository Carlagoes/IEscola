using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEscola.Infra.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly List<Professor> _professorList = new List<Professor>
        {
            new Professor(Guid.Parse("9F119207-3ED2-41B2-AABA-B9D94FB43937"), "Antonio", "123456", new DateTime(1990, 2, 27)),
            new Professor(Guid.Parse("6060BFC6-6311-473E-827E-FFD7C9A7B260"), "Maria", "123444", new DateTime(1993, 3, 11)),
            new Professor(Guid.Parse("C3C8AD06-B623-4FD6-8A93-0DCDCA9E0BE4"), "João", "133356", new DateTime(1984, 4, 13)),
            new Professor(Guid.Parse("4085FD30-3B97-4482-B189-E045FD309AD0"), "Luis", "111456", new DateTime(1983, 5, 07)),
            new Professor(Guid.Parse("465BCF15-6D8E-4DC6-8ECB-E61D56713DBC"), "Rose", "122226", new DateTime(1998, 6, 03)),
            new Professor(Guid.Parse("465BCF15-6D8E-4DC6-8ECB-E61D56713DBC"), "Rose", "122226", new DateTime(1998, 6, 03)),
        };

        public void Delete(Professor professor)
        {
            _professorList.Remove(professor);
        }

        public IEnumerable<Professor> Get()
        {
            return _professorList;
        }

        public Professor Get(Guid id)
        {
            return _professorList.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Professor professor)
        {
            _professorList.Add(professor);
        }

        public void Update(Professor professor)
        {
            var prof = Get(professor.Id);

            _professorList.Remove(prof);

            _professorList.Add(professor);
        }
    }
}
