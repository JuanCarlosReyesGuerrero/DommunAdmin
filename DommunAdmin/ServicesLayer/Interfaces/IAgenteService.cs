using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IAgenteService
    {
        Task<List<AgenteDto>> GetAllAgentes();
        Task<AgenteDto> GetAgenteById(int? Id);
        Task<ResultadoApi> InsertAgente(AgenteDto objeto);
        Task<ResultadoApi> UpdateAgente(AgenteDto objeto);
        Task<ResultadoApi> DeleteAgente(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
