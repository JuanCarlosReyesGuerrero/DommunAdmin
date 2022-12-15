using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface INumeroHabitacionService
    {
        Task<List<NumeroHabitacionDto>> GetAllNumeroHabitaciones();
        Task<NumeroHabitacionDto> GetNumeroHabitacionById(int? Id);
        Task<ResultadoApi> InsertNumeroHabitacion(NumeroHabitacionDto objeto);
        Task<ResultadoApi> UpdateNumeroHabitacion(NumeroHabitacionDto objeto);
        Task<ResultadoApi> DeleteNumeroHabitacion(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
