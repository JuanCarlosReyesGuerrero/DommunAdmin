using DommunAdmin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ITipoOfertaService
    {
        Task<List<TipoOfertaDto>> GetAllTipoOfertas();
        Task<TipoOfertaDto> GetTipoOfertaById(int? Id);
        Task<ResultadoApi> InsertTipoOferta(TipoOfertaDto objeto);
        Task<ResultadoApi> UpdateTipoOferta(TipoOfertaDto objeto);
        Task<ResultadoApi> DeleteTipoOferta(int? Id);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
