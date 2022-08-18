using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IPropiedadService
    {
        Task<List<PropiedadDto>> GetAllPropiedades();
        Task<PropiedadDto> GetPropiedadById(int? Id);
        Task<ResultdoApi> InsertPropiedad(PropiedadDto objeto);
        Task<ResultdoApi> UpdatePropiedad(PropiedadDto objeto);
        Task<ResultdoApi> DeletePropiedad(int? Id);
    }
}
