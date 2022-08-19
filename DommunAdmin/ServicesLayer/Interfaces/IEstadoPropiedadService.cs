using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IEstadoPropiedadService
    {
        Task<List<EstadoPropiedadDto>> GetAllEstadoPropiedades();
        Task<EstadoPropiedadDto> GetEstadoPropiedadById(int? Id);
        Task<ResultadoApi> InsertEstadoPropiedad(EstadoPropiedadDto objeto);
        Task<ResultadoApi> UpdateEstadoPropiedad(EstadoPropiedadDto objeto);
        Task<ResultadoApi> DeleteEstadoPropiedad(int? Id);
    }
}
