using DomainLayer.Dtos;
using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IEstadoPropiedadService
    {
        Task<List<EstadoPropiedadDto>> GetAllEstadoPropiedads();
        Task<EstadoPropiedadDto> GetEstadoPropiedadById(int? Id);
        Task<ResultdoApi> InsertEstadoPropiedad(EstadoPropiedadDto objeto);
        Task<ResultdoApi> UpdateEstadoPropiedad(EstadoPropiedadDto objeto);
        Task<ResultdoApi> DeleteEstadoPropiedad(int? Id);
    }
}
