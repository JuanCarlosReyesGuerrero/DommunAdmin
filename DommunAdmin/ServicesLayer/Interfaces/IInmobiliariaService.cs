using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IInmobiliariaService
    {
        Task<List<InmobiliariaDto>> GetAllInmobiliarias();        
        Task<InmobiliariaDto> GetInmobiliariaById(int? Id);
        Task<bool> InsertInmobiliaria(InmobiliariaDto objeto);
        Task<bool> UpdateInmobiliaria(InmobiliariaDto objeto);
        Task<bool> DeleteInmobiliaria(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
