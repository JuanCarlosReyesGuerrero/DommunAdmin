using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ICaracteristicaPropiedadService
    {
        Task<List<CaracteristicaPropiedadDto>> GetAllCaracteristicaPropiedades();
        Task<CaracteristicaPropiedadDto> GetCaracteristicaPropiedadById(int? Id);
        Task<ResultadoApi> InsertCaracteristicaPropiedad(CaracteristicaPropiedadDto objeto);
        Task<ResultadoApi> UpdateCaracteristicaPropiedad(CaracteristicaPropiedadDto objeto);
        Task<ResultadoApi> DeleteCaracteristicaPropiedad(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
