using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IInmobiliariaService
    {
        Task<List<InmobiliariaDto>> GetAllInmobiliarias();        
        Task<InmobiliariaDto> GetInmobiliariaById(int? Id);
        Task<ResultdoApi> InsertInmobiliaria(InmobiliariaDto objeto);
        Task<ResultdoApi> UpdateInmobiliaria(InmobiliariaDto objeto);
        Task<ResultdoApi> DeleteInmobiliaria(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
