using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEscola.Infra.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly List<Disciplina> disciplinaList = new List<Disciplina>
        {
            new Disciplina(Guid.Parse("9F119207-3ED2-41B2-AABA-B9D94FB43937"), "Português", "A mais Importante"),
            new Disciplina(Guid.Parse("6060BFC6-6311-473E-827E-FFD7C9A7B260"), "Matemática", "A melhor de todas"),
            new Disciplina(Guid.Parse("C3C8AD06-B623-4FD6-8A93-0DCDCA9E0BE4"), "Geografia", " Para entender o mundo e para onde vamos"),
            new Disciplina(Guid.Parse("4085FD30-3B97-4482-B189-E045FD309AD0"), "Ciências", "Para entender como tudo funciona"),
            new Disciplina(Guid.Parse("465BCF15-6D8E-4DC6-8ECB-E61D56713DBC"), "Fisica", "Para experimentar a Matematica"),
            new Disciplina(Guid.Parse("922926ED-36B4-427A-A624-A41002591579"), "Química", "Para aprender que NaCl é sal"),
            new Disciplina(Guid.Parse("5E7A2C37-E312-48E1-98F5-680A95907A29"), "Filosofia", "Para viajar nas Ideias"),

        };

        public IEnumerable<Disciplina> Get()
        {
            return disciplinaList;
        }

        public Disciplina Get(Guid id)
        {
            return disciplinaList.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Disciplina disciplina)
        {
            disciplinaList.Add(disciplina);
        }

        public void Update(Disciplina disciplina)
        {
            var disc = Get(disciplina.Id);

            disciplinaList.Remove(disc);

            disciplinaList.Add(disciplina);
        }

        public void Delete(Disciplina disciplina)
        {
            disciplinaList.Remove(disciplina);
        }
    }
}
