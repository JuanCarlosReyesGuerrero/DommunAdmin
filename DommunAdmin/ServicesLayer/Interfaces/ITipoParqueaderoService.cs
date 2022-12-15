using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ITipoParqueaderoService
    {
        Task<List<TipoParqueaderoDto>> GetAllTipoParqueaderos();
        Task<TipoParqueaderoDto> GetTipoParqueaderoById(int? Id);
        Task<ResultadoApi> InsertTipoParqueadero(TipoParqueaderoDto objeto);
        Task<ResultadoApi> UpdateTipoParqueadero(TipoParqueaderoDto objeto);
        Task<ResultadoApi> DeleteTipoParqueadero(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
