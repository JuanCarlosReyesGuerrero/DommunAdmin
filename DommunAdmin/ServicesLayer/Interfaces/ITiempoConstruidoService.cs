using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ITiempoConstruidoService
    {
        Task<List<TiempoConstruidoDto>> GetAllTiempoConstruidos();
        Task<TiempoConstruidoDto> GetTiempoConstruidoById(int? Id);
        Task<ResultadoApi> InsertTiempoConstruido(TiempoConstruidoDto objeto);
        Task<ResultadoApi> UpdateTiempoConstruido(TiempoConstruidoDto objeto);
        Task<ResultadoApi> DeleteTiempoConstruido(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
