using AutoMapper;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DommunAdmin.ServicesLayer.Services
{
    public class TipoOfertaService : ITipoOfertaService
    {
        private readonly IAutenticarService autenticarService;
        private readonly IMapper mapper;

        public TipoOfertaService(IAutenticarService _autenticarService, IMapper _mapper)
        {
            this.autenticarService = _autenticarService;
            this.mapper = _mapper;
        }

        public async Task<ResultadoApi> DeleteTipoOferta(int? Id)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.DeleteAsync($"api/TipoOferta/DeleteTipoOferta/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<TipoOfertaDto> GetTipoOfertaById(int? Id)
        {
            TipoOfertaDto objeto = new TipoOfertaDto();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync($"api/TipoOferta/GetTipoOferta?Id={Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    objeto = mapper.Map<TipoOfertaDto>(resultado.Data);
            }

            return objeto;
        }

        public async Task<ResultadoApi> InsertTipoOferta(TipoOfertaDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/TipoOferta/InsertTipoOferta", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<List<TipoOfertaDto>> GetAllTipoOfertas()
        {
            List<TipoOfertaDto> lista = new List<TipoOfertaDto>();

            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync("api/TipoOferta/GetAllTipoOfertas");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    lista = mapper.Map<List<TipoOfertaDto>>(resultado.Data);
            }

            return lista;
        }

        public async Task<ResultadoApi> UpdateTipoOferta(TipoOfertaDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/TipoOferta/UpdateTipoOferta", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<List<SelectListItem>> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();

            List<TipoOfertaDto> elements = new List<TipoOfertaDto>();

            elements = await GetAllTipoOfertas();

            foreach (var element in elements)
            {
                if (element.isActive == true)
                    selectList.Add(new SelectListItem
                    {
                        Value = element.id.ToString(),
                        Text = element.nombre
                    });
            }

            return selectList;
        }
    }
}
