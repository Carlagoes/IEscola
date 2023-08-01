using IEscola.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IEscola.Infra.API
{
    public class ViaCepApi : IViaCepApi
    {
        private readonly HttpClient _httpClient;
        public ViaCepApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ExisteCep(string cep)
        {
           var response =  await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
           var payload = await response.Content.ReadAsStringAsync();
            var deserializado = JsonConvert.DeserializeObject<ViaCepResponse>(payload);

            if (deserializado.Erro)
            {
                return false;
            }

            return true;
        }
    }

    public class ViaCepResponse
    {
        [JsonProperty("cep", NullValueHandling = NullValueHandling.Ignore)]
        public string Cep { get; set; }

        [JsonProperty("logradouro", NullValueHandling = NullValueHandling.Ignore)]
        public string Logradouro { get; set; }

        [JsonProperty("complemento", NullValueHandling = NullValueHandling.Ignore)]
        public string Complemento { get; set; }

        [JsonProperty("bairro", NullValueHandling = NullValueHandling.Ignore)]
        public string Bairro { get; set; }

        [JsonProperty("localidade", NullValueHandling = NullValueHandling.Ignore)]
        public string Localidade { get; set; }

        [JsonProperty("uf", NullValueHandling = NullValueHandling.Ignore)]
        public string Uf { get; set; }

        [JsonProperty("ibge", NullValueHandling = NullValueHandling.Ignore)]
        public string Ibge { get; set; }

        [JsonProperty("gia", NullValueHandling = NullValueHandling.Ignore)]
        public string Gia { get; set; }

        [JsonProperty("ddd", NullValueHandling = NullValueHandling.Ignore)]
        public string Ddd { get; set; }

        [JsonProperty("siafi", NullValueHandling = NullValueHandling.Ignore)]
        public string Siafi { get; set; }
        
        [JsonProperty("erro", NullValueHandling = NullValueHandling.Ignore)]
        public bool Erro { get; set; }

    }
}
