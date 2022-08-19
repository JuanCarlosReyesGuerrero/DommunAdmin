using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IPropiedadService
    {
        Task<List<PropiedadDto>> GetAllPropiedades();
        Task<PropiedadDto> GetPropiedadById(int? Id);
        Task<ResultadoApi> InsertPropiedad(PropiedadDto objeto);
        Task<ResultadoApi> UpdatePropiedad(PropiedadDto objeto);
        Task<ResultadoApi> DeletePropiedad(int? Id);
    }
}
