using AutoMapper;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DommunAdmin.ServicesLayer.Services
{
    public class CiudadService : ICiudadService
    {
        private readonly IAutenticarService autenticarService;
        private readonly IMapper mapper;

        public CiudadService(IAutenticarService _autenticarService, IMapper _mapper)
        {
            this.autenticarService = _autenticarService;
            this.mapper = _mapper;
        }

        public async Task<ResultdoApi> DeleteCiudad(int? Id)
        {
            ResultdoApi resultado = new ResultdoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.DeleteAsync($"api/Ciudad/DeleteCiudad/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<CiudadDto> GetCiudadById(int? Id)
        {
            CiudadDto objeto = new CiudadDto();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync($"api/Ciudad/GetCiudad?Id={Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    objeto = mapper.Map<CiudadDto>(resultado.Data);
            }

            return objeto;
        }

        public async Task<ResultdoApi> InsertCiudad(CiudadDto objeto)
        {
            ResultdoApi resultado = new ResultdoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/Ciudad/InsertCiudad", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<List<CiudadDto>> GetAllCiudades()
        {
            List<CiudadDto> lista = new List<CiudadDto>();

            ResultdoApi resultado = new ResultdoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync("api/Ciudad/GetAllCiudades");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    lista = mapper.Map<List<CiudadDto>>(resultado.Data);
            }

            return lista;
        }

        public async Task<ResultdoApi> UpdateCiudad(CiudadDto objeto)
        {
            ResultdoApi resultado = new ResultdoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/Ciudad/UpdateCiudad", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);
            }

            return resultado;
        }
    }
}
