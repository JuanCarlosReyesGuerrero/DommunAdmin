using AutoMapper;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DommunAdmin.ServicesLayer.Services
{
    public class CaracteristicaParqueaderoService : ICaracteristicaParqueaderoService
    {
        private readonly IAutenticarService autenticarService;
        private readonly IMapper mapper;

        public CaracteristicaParqueaderoService(IAutenticarService _autenticarService, IMapper _mapper)
        {
            this.autenticarService = _autenticarService;
            this.mapper = _mapper;
        }

        public async Task<ResultadoApi> DeleteCaracteristicaParqueadero(int? Id)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.DeleteAsync($"api/CaracteristicaParqueadero/DeleteCaracteristicaParqueadero/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<CaracteristicaParqueaderoDto> GetCaracteristicaParqueaderoById(int? Id)
        {
            CaracteristicaParqueaderoDto objeto = new CaracteristicaParqueaderoDto();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync($"api/CaracteristicaParqueadero/GetCaracteristicaParqueadero?Id={Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    objeto = mapper.Map<CaracteristicaParqueaderoDto>(resultado.Data);
            }

            return objeto;
        }

        public async Task<ResultadoApi> InsertCaracteristicaParqueadero(CaracteristicaParqueaderoDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/CaracteristicaParqueadero/InsertCaracteristicaParqueadero", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<ResultadoApi> UpdateCaracteristicaParqueadero(CaracteristicaParqueaderoDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/CaracteristicaParqueadero/UpdateCaracteristicaParqueadero", content);

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

            List<CaracteristicaParqueaderoDto> elements = new List<CaracteristicaParqueaderoDto>();

            elements = await GetAllCaracteristicaParqueaderos();

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

        public async Task<List<CaracteristicaParqueaderoDto>> GetAllCaracteristicaParqueaderos()
        {
            List<CaracteristicaParqueaderoDto> lista = new List<CaracteristicaParqueaderoDto>();

            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync("api/CaracteristicaParqueadero/GetAllCaracteristicaParqueaderos");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    lista = mapper.Map<List<CaracteristicaParqueaderoDto>>(resultado.Data);
            }

            return lista;
        }
    }
}