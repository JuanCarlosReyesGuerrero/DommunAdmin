using AutoMapper;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection;
using System.Text;

namespace DommunAdmin.ServicesLayer.Services
{
    public class AgenteService : IAgenteService
    {
        private readonly IAutenticarService autenticarService;
        private readonly IMapper mapper;

        public AgenteService(IAutenticarService _autenticarService, IMapper _mapper)
        {
            this.autenticarService = _autenticarService;
            this.mapper = _mapper;
        }

        public async Task<ResultadoApi> DeleteAgente(int? Id)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.DeleteAsync($"api/Agente/DeleteAgente/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
            }

            return resultado;
        }

        public async Task<AgenteDto> GetAgenteById(int? Id)
        {
            AgenteDto objeto = new AgenteDto();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await cliente.GetAsync($"api/Agente/GetAgente?Id={Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);

                if (resultado.Data.ToString() != "[]" && resultado.Data != null)
                    objeto = mapper.Map<AgenteDto>(resultado.Data);
            }

            return objeto;
        }

        public async Task<ResultadoApi> InsertAgente(AgenteDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            try
            {
                var _token = await autenticarService.GetToken();
                var _baseUrl = await autenticarService.GetBaseUrl();

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + "api/Agente/InsertAgente");
                request.Headers.Add("Authorization", "Bearer " + _token);
                var content = new MultipartFormDataContent();

                if (objeto.slug == null) objeto.slug = "";
                if (objeto.nombres == null) objeto.nombres = "";
                if (objeto.apellidos == null) objeto.apellidos = "";
                if (objeto.email == null) objeto.email = "";
                if (objeto.fotoPerfil == null) objeto.fotoPerfil = "";
                if (objeto.descripcionPerfil == null) objeto.descripcionPerfil = "";
                if (objeto.celular == null) objeto.celular = "";
                if (objeto.facebook == null) objeto.facebook = "";
                if (objeto.twitter == null) objeto.twitter = "";
                if (objeto.linkedin == null) objeto.linkedin = "";
                if (objeto.instagram == null) objeto.instagram = "";
                if (objeto.website == null) objeto.website = "";
                if (objeto.inmobiliariaId == null) objeto.inmobiliariaId = 0;
                if (objeto.isActive == null) objeto.isActive = false;

                content.Add(new StringContent(objeto.slug), "Slug");
                content.Add(new StringContent(objeto.nombres), "Nombres");
                content.Add(new StringContent(objeto.apellidos), "Apellidos");
                content.Add(new StringContent(objeto.email), "Email");
                content.Add(new StringContent(objeto.descripcionPerfil), "DescripcionPerfil");
                content.Add(new StringContent(objeto.celular), "Celular");
                content.Add(new StringContent(objeto.facebook), "Facebook");
                content.Add(new StringContent(objeto.twitter), "Twitter");
                content.Add(new StringContent(objeto.linkedin), "Linkedin");
                content.Add(new StringContent(objeto.instagram), "Instagram");
                content.Add(new StringContent(objeto.website), "Website");
                content.Add(new StringContent(objeto.inmobiliariaId.ToString()), "InmobiliariaId");
                content.Add(new StringContent(objeto.isActive.ToString()), "IsActive");

                if (objeto.foto != null)
                {
                    var imageContent = new StreamContent(objeto.foto.OpenReadStream());
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Image.Jpeg);
                    content.Add(imageContent, "Foto", objeto.foto.FileName);
                }

                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    resultado = JsonConvert.DeserializeObject<ResultadoApi>(json_respuesta);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;
        }

        public async Task<List<AgenteDto>> GetAllAgentes()
        {
            List<AgenteDto> lista = new List<AgenteDto>();

            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

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

        public async Task<ResultadoApi> UpdateAgente(AgenteDto objeto)
        {
            ResultadoApi resultado = new ResultadoApi();

            var _token = await autenticarService.GetToken();
            var _baseUrl = await autenticarService.GetBaseUrl();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("api/Agente/UpdateAgente", content);

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

            List<AgenteDto> elements = new List<AgenteDto>();

            elements = await GetAllAgentes();

            foreach (var element in elements)
            {
                if (element.isActive == true)
                    selectList.Add(new SelectListItem
                    {
                        Value = element.id.ToString(),
                        Text = element.nombres + " " + element.apellidos
                    });
            }

            return selectList;
        }
    }
}
