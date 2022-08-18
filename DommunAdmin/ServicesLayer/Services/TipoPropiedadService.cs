using AutoMapper;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DommunAdmin.ServicesLayer.Services
{
    public class TipoPropiedadService : ITipoPropiedadService
    {
        private readonly IAutenticarService autenticarService;
        private readonly IMapper mapper;

        public TipoPropiedadService(IAutenticarService _autenticarService, IMapper _mapper)
        {
            this.autenticarService = _autenticarService;
            this.mapper = _mapper;
        }

        public async Task<ResultdoApi> DeleteTipoPropiedad(int? Id)
        {
            ResultdoApi resultado = new ResultdoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.DeleteAsync($"api/TipoPropiedad/DeleteTipoPropiedad/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<TipoPropiedadDto> GetTipoPropiedadById(int? Id)
        {
            TipoPropiedadDto objeto = new TipoPropiedadDto();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync($"api/TipoPropiedad/GetTipoPropiedad?Id={Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    objeto = mapper.Map<TipoPropiedadDto>(resultado.Data);
            }

            return objeto;
        }

        public async Task<ResultdoApi> InsertTipoPropiedad(TipoPropiedadDto objeto)
        {
            ResultdoApi resultado = new ResultdoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/TipoPropiedad/InsertTipoPropiedad", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<List<TipoPropiedadDto>> GetAllTipoPropiedades()
        {
            List<TipoPropiedadDto> lista = new List<TipoPropiedadDto>();

            ResultdoApi resultado = new ResultdoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync("api/TipoPropiedad/GetAllTipoPropiedades");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    lista = mapper.Map<List<TipoPropiedadDto>>(resultado.Data);
            }

            return lista;
        }

        public async Task<ResultdoApi> UpdateTipoPropiedad(TipoPropiedadDto objeto)
        {
            ResultdoApi resultado = new ResultdoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/TipoPropiedad/UpdateTipoPropiedad", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);
            }

            return resultado;
        }
    }
}
