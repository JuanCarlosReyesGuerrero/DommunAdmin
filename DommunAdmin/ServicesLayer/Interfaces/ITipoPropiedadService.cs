using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ITipoPropiedadService
    {
        Task<List<TipoPropiedadDto>> GetAllTipoPropiedades();
        Task<TipoPropiedadDto> GetTipoPropiedadById(int? Id);
        Task<ResultadoApi> InsertTipoPropiedad(TipoPropiedadDto objeto);
        Task<ResultadoApi> UpdateTipoPropiedad(TipoPropiedadDto objeto);
        Task<ResultadoApi> DeleteTipoPropiedad(int? Id);
    }
}
