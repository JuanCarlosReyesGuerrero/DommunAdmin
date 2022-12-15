using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IEstratoService
    {
        Task<List<EstratoDto>> GetAllEstratos();
        Task<EstratoDto> GetEstratoById(int? Id);
        Task<ResultadoApi> InsertEstrato(EstratoDto objeto);
        Task<ResultadoApi> UpdateEstrato(EstratoDto objeto);
        Task<ResultadoApi> DeleteEstrato(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
