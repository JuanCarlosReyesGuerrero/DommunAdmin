using AutoMapper;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DommunAdmin.ServicesLayer.Services
{
    public class ServiceApi : IServiceApi
    {
        private static string? _key;
        private static string? _apiKey;
        private static string? _baseUrl;
        private static string? _token;

        private readonly IMapper mapper;

        public ServiceApi(IMapper _mapper)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _key = builder.GetSection("ApiSettings:Key").Value;
            _apiKey = builder.GetSection("ApiSettings:ApiKey").Value;
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;

            this.mapper = _mapper;
        }

        public async Task Autenticar()
        {
            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var credenciales = new AuthCredencial() { Key = _key, ApiKey = _apiKey };

            var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/AuthToken", content);

            var json_respuesta = await response.Content.ReadAsStringAsync();


            var resultado = JsonConvert.DeserializeObject<ResultAuthCredencial>(json_respuesta);

            _token = resultado.Token;

        }

        public async Task<bool> DeleteAgente(int? Id)
        {
            bool respuesta = false;

            await Autenticar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.DeleteAsync($"api/Agente/DeleteAgente/{Id}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<AgenteDto> GetAgenteById(int? Id)
        {
            AgenteDto objeto = new AgenteDto();

            await Autenticar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync($"api/Agente/GetAgente/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    objeto = mapper.Map<AgenteDto>(resultado.Data);               
            }

            return objeto;
        }

        public async Task<bool> InsertAgente(AgenteDto objeto)
        {
            bool respuesta = false;

            await Autenticar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/Agente/InsertAgente", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<List<AgenteDto>> Lista()
        {
            List<AgenteDto> lista = new List<AgenteDto>();

            ResultadoApi resultado = new ResultadoApi();

            await Autenticar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync("api/Agente/GetAllAgentes");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    lista = mapper.Map<List<AgenteDto>>(resultado.Data);
            }

            return lista;
        }

        public async Task<bool> UpdateAgente(AgenteDto objeto)
        {
            bool respuesta = false;

            await Autenticar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/Agente/UpdateAgente", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}