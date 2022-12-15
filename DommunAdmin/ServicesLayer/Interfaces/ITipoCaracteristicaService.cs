using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ITipoCaracteristicaService
    {
        Task<List<TipoCaracteristicaDto>> GetAllTipoCaracteristicas();
        Task<TipoCaracteristicaDto> GetTipoCaracteristicaById(int? Id);
        Task<ResultadoApi> InsertTipoCaracteristica(TipoCaracteristicaDto objeto);
        Task<ResultadoApi> UpdateTipoCaracteristica(TipoCaracteristicaDto objeto);
        Task<ResultadoApi> DeleteTipoCaracteristica(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
