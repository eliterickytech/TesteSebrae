using Microsoft.Extensions.Configuration;
using TesteSebrae.Domain.Entities;
using TesteSebrae.Domain.Interfaces;

namespace TesteSebrae.Infra
{
    public class CepRepository : ICepRepository
    {
        private readonly IConfiguration _configuration;

        public CepRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CepModel> GetCEPDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var endpoint = _configuration.GetSection("Cep:Endpoint").Value;
                var result = await client.GetAsync(endpoint);

                if (!result.IsSuccessStatusCode) return default;

                var content = await result.Content.ReadAsStringAsync();

                return Newtonsoft.Json.JsonConvert.DeserializeObject<CepModel>(content);
            }
        }
    }
}