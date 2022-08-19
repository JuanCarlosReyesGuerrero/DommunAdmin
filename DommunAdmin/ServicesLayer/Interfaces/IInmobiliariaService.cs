using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IInmobiliariaService
    {
        Task<List<InmobiliariaDto>> GetAllInmobiliarias();        
        Task<InmobiliariaDto> GetInmobiliariaById(int? Id);
        Task<ResultadoApi> InsertInmobiliaria(InmobiliariaDto objeto);
        Task<ResultadoApi> UpdateInmobiliaria(InmobiliariaDto objeto);
        Task<ResultadoApi> DeleteInmobiliaria(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
