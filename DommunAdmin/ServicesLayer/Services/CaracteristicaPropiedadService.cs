using AutoMapper;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DommunAdmin.ServicesLayer.Services
{
    public class CaracteristicaPropiedadService : ICaracteristicaPropiedadService
    {
        private readonly IAutenticarService autenticarService;
        private readonly IMapper mapper;

        public CaracteristicaPropiedadService(IAutenticarService _autenticarService, IMapper _mapper)
        {
            this.autenticarService = _autenticarService;
            this.mapper = _mapper;
        }

        public async Task<ResultadoApi> DeleteCaracteristicaPropiedad(int? Id)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.DeleteAsync($"api/CaracteristicaPropiedad/DeleteCaracteristicaPropiedad/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<CaracteristicaPropiedadDto> GetCaracteristicaPropiedadById(int? Id)
        {
            CaracteristicaPropiedadDto objeto = new CaracteristicaPropiedadDto();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync($"api/CaracteristicaPropiedad/GetCaracteristicaPropiedad?Id={Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    objeto = mapper.Map<CaracteristicaPropiedadDto>(resultado.Data);
            }

            return objeto;
        }

        public async Task<ResultadoApi> InsertCaracteristicaPropiedad(CaracteristicaPropiedadDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/CaracteristicaPropiedad/InsertCaracteristicaPropiedad", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<ResultadoApi> UpdateCaracteristicaPropiedad(CaracteristicaPropiedadDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/CaracteristicaPropiedad/UpdateCaracteristicaPropiedad", content);

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

            List<CaracteristicaPropiedadDto> elements = new List<CaracteristicaPropiedadDto>();

            elements = await GetAllCaracteristicaPropiedades();

            foreach (var element in elements)
            {
                if (element.isActive == true)
                    selectList.Add(new SelectListItem
                    {
                        Value = element.id.ToString(),
                        Text = element.propiedadId.ToString(),
                    });
            }

            return selectList;
        }

        public async Task<List<CaracteristicaPropiedadDto>> GetAllCaracteristicaPropiedades()
        {
            List<CaracteristicaPropiedadDto> lista = new List<CaracteristicaPropiedadDto>();

            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync("api/CaracteristicaPropiedad/GetAllCaracteristicaPropiedades");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    lista = mapper.Map<List<CaracteristicaPropiedadDto>>(resultado.Data);
            }

            return lista;
        }
    }
}