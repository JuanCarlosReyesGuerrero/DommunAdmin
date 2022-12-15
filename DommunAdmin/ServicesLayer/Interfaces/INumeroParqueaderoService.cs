using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface INumeroParqueaderoService
    {
        Task<List<NumeroParqueaderoDto>> GetAllNumeroParqueaderos();
        Task<NumeroParqueaderoDto> GetNumeroParqueaderoById(int? Id);
        Task<ResultadoApi> InsertNumeroParqueadero(NumeroParqueaderoDto objeto);
        Task<ResultadoApi> UpdateNumeroParqueadero(NumeroParqueaderoDto objeto);
        Task<ResultadoApi> DeleteNumeroParqueadero(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
