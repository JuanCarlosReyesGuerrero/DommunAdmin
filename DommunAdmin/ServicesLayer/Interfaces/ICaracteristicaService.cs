using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ICaracteristicaService
    {
        Task<List<CaracteristicaDto>> GetAllCaracteristicas();
        Task<CaracteristicaDto> GetCaracteristicaById(int? Id);
        Task<ResultadoApi> InsertCaracteristica(CaracteristicaDto objeto);
        Task<ResultadoApi> UpdateCaracteristica(CaracteristicaDto objeto);
        Task<ResultadoApi> DeleteCaracteristica(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
