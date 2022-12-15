using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface INumeroBanoService
    {
        Task<List<NumeroBanoDto>> GetAllNumeroBanos();
        Task<NumeroBanoDto> GetNumeroBanoById(int? Id);
        Task<ResultadoApi> InsertNumeroBano(NumeroBanoDto objeto);
        Task<ResultadoApi> UpdateNumeroBano(NumeroBanoDto objeto);
        Task<ResultadoApi> DeleteNumeroBano(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
