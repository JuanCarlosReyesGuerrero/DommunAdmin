using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace DommunAdmin.ServicesLayer.Services
{
    public class AutenticarService : IAutenticarService
    {
        public AutenticarService()
        {

        }

        public async Task<string> GetToken()
        {
            string? _key;
            string? _apiKey;
            string? _baseUrl;
            string? _token;

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _key = builder.GetSection("ApiSettings:Key").Value;
            _apiKey = builder.GetSection("ApiSettings:ApiKey").Value;
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var credenciales = new AuthCredencial() { Key = _key, ApiKey = _apiKey };

            var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/AuthToken", content);

            var json_respuesta = await response.Content.ReadAsStringAsync();


            var resultado = JsonConvert.DeserializeObject<ResultAuthCredencial>(json_respuesta);

            _token = resultado.Token;

            return _token;
        }

        public string GetBaseUrl()
        {
            string? _baseUrl;


            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;

            return _baseUrl;
        }
    }
}
