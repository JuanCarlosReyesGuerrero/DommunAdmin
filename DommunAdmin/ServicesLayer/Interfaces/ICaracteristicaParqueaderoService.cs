using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ICaracteristicaParqueaderoService
    {
        Task<List<CaracteristicaParqueaderoDto>> GetAllCaracteristicaParqueaderos();
        Task<CaracteristicaParqueaderoDto> GetCaracteristicaParqueaderoById(int? Id);
        Task<ResultadoApi> InsertCaracteristicaParqueadero(CaracteristicaParqueaderoDto objeto);
        Task<ResultadoApi> UpdateCaracteristicaParqueadero(CaracteristicaParqueaderoDto objeto);
        Task<ResultadoApi> DeleteCaracteristicaParqueadero(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
