using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ITipoPropiedadService
    {
        Task<List<TipoPropiedadDto>> GetAllTipoPropiedades();
        Task<TipoPropiedadDto> GetTipoPropiedadById(int? Id);
        Task<ResultdoApi> InsertTipoPropiedad(TipoPropiedadDto objeto);
        Task<ResultdoApi> UpdateTipoPropiedad(TipoPropiedadDto objeto);
        Task<ResultdoApi> DeleteTipoPropiedad(int? Id);
    }
}
