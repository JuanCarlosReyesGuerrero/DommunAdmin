﻿using AutoMapper;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;

namespace DommunAdmin.ServicesLayer.Services
{
    public class InmobiliariaService : IInmobiliariaService
    {
        private readonly IAutenticarService autenticarService;
        private readonly IMapper mapper;

        public InmobiliariaService(IAutenticarService _autenticarService, IMapper _mapper)
        {
            this.autenticarService = _autenticarService;
            this.mapper = _mapper;
        }

        public async Task<bool> DeleteInmobiliaria(int? Id)
        {
            bool respuesta = false;

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.DeleteAsync($"api/Inmobiliaria/DeleteInmobiliaria/{Id}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<InmobiliariaDto> GetInmobiliariaById(int? Id)
        {
            InmobiliariaDto objeto = new InmobiliariaDto();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync($"api/Inmobiliaria/GetInmobiliaria?Id={Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    objeto = mapper.Map<InmobiliariaDto>(resultado.Data);
            }

            return objeto;
        }

        public async Task<bool> InsertInmobiliaria(InmobiliariaDto objeto)
        {
            bool respuesta = false;

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("api/Inmobiliaria/InsertInmobiliaria", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<List<InmobiliariaDto>> GetAllInmobiliarias()
        {
            List<InmobiliariaDto> lista = new List<InmobiliariaDto>();

            ResultdoApi resultado = new ResultdoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync("api/Inmobiliaria/GetAllInmobiliarias");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultdoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    lista = mapper.Map<List<InmobiliariaDto>>(resultado.Data);
            }

            return lista;
        }

        public async Task<bool> UpdateInmobiliaria(InmobiliariaDto objeto)
        {
            bool respuesta = false;

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/Inmobiliaria/UpdateInmobiliaria", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<List<SelectListItem>> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();

            List<InmobiliariaDto> elements = new List<InmobiliariaDto>();

            elements = await GetAllInmobiliarias();

            foreach (var element in elements)
            {
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
