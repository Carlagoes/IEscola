using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IEscola.Domain.Interfaces
{
    public interface IViaCepApi
    {
        Task<bool> ExisteCep(string cep);
    }
}
