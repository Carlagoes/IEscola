using IEscola.Application.HttpObjects.Endereco.Request;
using IEscola.Application.HttpObjects.Endereco.Response;
using IEscola.Application.Interfaces;
using IEscola.Domain.Entities;
using IEscola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Application.Services
{
    public class EnderecoService : ServiceBase, IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IViaCepApi _viaCepApi;

        public EnderecoService(IEnderecoRepository repository,
            INotificador notificador, IProfessorRepository professorRepository, IViaCepApi viaCepApi) : base(notificador)
        {
            _repository = repository;
            _professorRepository = professorRepository;
            _viaCepApi = viaCepApi;
        }


        public async Task<IEnumerable<EnderecoResponse>> GetAsync()
        {
            var list = await _repository.GetAsync();
            return list.Select(d => Map(d));
        }
        public async Task<EnderecoResponse> GetAsync(Guid ProfessorId)
        {
            if (Guid.Empty == ProfessorId) 
            {
                NotificarErro("Professor inválido");
                return default;
            }
            var Endereco = await _repository.GetAsync(ProfessorId);

            if (Endereco is null)
            {
                NotificarErro("Endereco não encontrado");
                return default;
            };
            // Retornar
            return Map(Endereco);
        }
        public async Task<EnderecoResponse> InsertAsync(EnderecoInsertRequest EnderecoRequest)
        {
            // Validar a Endereco
            if (string.IsNullOrWhiteSpace(EnderecoRequest.Logradouro))
                NotificarErro("Logradouro não preenchido");
            if (string.IsNullOrWhiteSpace(EnderecoRequest.Numero.ToString()))
                NotificarErro("Numero não preenchido");
            if (string.IsNullOrWhiteSpace(EnderecoRequest.Bairro))
                NotificarErro("Bairro não preenchido");
            if (string.IsNullOrWhiteSpace(EnderecoRequest.Cep))
                NotificarErro("CEP não preenchido");
            if (string.IsNullOrWhiteSpace(EnderecoRequest.Cidade))
                NotificarErro("Cidade não preenchido");
            if (string.IsNullOrWhiteSpace(EnderecoRequest.UF))
                NotificarErro("Estado não preenchido");
            if (TemNotificacao())
                return default;


            var existeCep = await _viaCepApi.ExisteCep(EnderecoRequest.Cep);
            if (!existeCep)
            {
                NotificarErro("Cep não válido");
            }

            // Mapear para o objeto de domínio
            var id = Guid.NewGuid();

            var Endereco = new Endereco(EnderecoRequest.Logradouro, EnderecoRequest.Numero, EnderecoRequest.Bairro,
                EnderecoRequest.Cep, EnderecoRequest.Cidade, EnderecoRequest.UF, EnderecoRequest.ProfessorId)
            {
                Logradouro = "TesteRuaService", Numero = 1478, Bairro = "TesteBairroService",
                Cidade = "TesteCidadeService", UF = "MG"

            };

            // Processar
            await _repository.InsertAsync(Endereco);
            // Retornar
            return Map(Endereco);
        }
        public async Task<EnderecoResponse> UpdateAsync(EnderecoUpdateRequest EnderecoRequest)
        {
            // Validar a Endereco
            if (string.IsNullOrWhiteSpace(EnderecoRequest.Numero.ToString()))
                NotificarErro("Numero não preenchido");
            if (string.IsNullOrWhiteSpace(EnderecoRequest.Bairro))
                NotificarErro("Bairro não preenchido");
            if (string.IsNullOrWhiteSpace(EnderecoRequest.Cep))
                NotificarErro("CEP não preenchido");
            if (string.IsNullOrWhiteSpace(EnderecoRequest.Cidade))
                NotificarErro("Cidade não preenchido");
            if (string.IsNullOrWhiteSpace(EnderecoRequest.UF))
                NotificarErro("Estado não preenchido");
            if (TemNotificacao())
                return default;

            // Validar se a Endereco do Id existe
            var cep = await GetAsync();
            if (cep is null) return default;

            var Endereco = new Endereco(EnderecoRequest.Logradouro, EnderecoRequest.Numero, 
                EnderecoRequest.Bairro, EnderecoRequest.Cep, EnderecoRequest.Cidade, 
                EnderecoRequest.UF, EnderecoRequest.ProfessorId)
            {
                Logradouro = "TesteRua", Numero = 123,
                Bairro = "TesteBairro", Cep = "12345678", 
                Cidade = "TesteCidade", UF = "TesteEstado"

            };

            if (EnderecoRequest.Erro)
                Endereco.CepValido();
            else
                Endereco.CepInvalido();
            await _repository.UpdateAsync(Endereco);
            return Map(Endereco);
        }

        public async Task DeleteAsync(Guid id)
        {
            var Endereco = await _repository.GetAsync(id);

            if (Endereco is null)
            {
                NotificarErro("Endereco não encontrada");
                return;
            }

            await _repository.DeleteAsync(Endereco);
        }

        #region Private Methods
        private static EnderecoResponse Map(Endereco Endereco)
        {
            return new EnderecoResponse
            {
                Logradouro = Endereco.Logradouro,
                Numero = Endereco.Numero,
                Cep = Endereco.Cep,
                Bairro = Endereco.Bairro,
                Cidade = Endereco.Cidade,
                UF = Endereco.UF
            };
        }
        #endregion
    }
}
