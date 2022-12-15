using AutoMapper;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DommunAdmin.ServicesLayer.Services
{
    public class NumeroParqueaderoService : INumeroParqueaderoService
    {
        private readonly IAutenticarService autenticarService;
        private readonly IMapper mapper;

        public NumeroParqueaderoService(IAutenticarService _autenticarService, IMapper _mapper)
        {
            this.autenticarService = _autenticarService;
            this.mapper = _mapper;
        }

        public async Task<ResultadoApi> DeleteNumeroParqueadero(int? Id)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.DeleteAsync($"api/NumeroParqueadero/DeleteNumeroParqueadero/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<NumeroParqueaderoDto> GetNumeroParqueaderoById(int? Id)
        {
            NumeroParqueaderoDto objeto = new NumeroParqueaderoDto();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync($"api/NumeroParqueadero/GetNumeroParqueadero?Id={Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    objeto = mapper.Map<NumeroParqueaderoDto>(resultado.Data);
            }

            return objeto;
        }

        public async Task<ResultadoApi> InsertNumeroParqueadero(NumeroParqueaderoDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/NumeroParqueadero/InsertNumeroParqueadero", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<ResultadoApi> UpdateNumeroParqueadero(NumeroParqueaderoDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/NumeroParqueadero/UpdateNumeroParqueadero", content);

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

            List<NumeroParqueaderoDto> elements = new List<NumeroParqueaderoDto>();

            elements = await GetAllNumeroParqueaderos();

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

        public async Task<List<NumeroParqueaderoDto>> GetAllNumeroParqueaderos()
        {
            List<NumeroParqueaderoDto> lista = new List<NumeroParqueaderoDto>();

            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync("api/NumeroParqueadero/GetAllNumeroParqueaderos");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    lista = mapper.Map<List<NumeroParqueaderoDto>>(resultado.Data);
            }

            return lista;
        }
    }
}