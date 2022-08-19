using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ICiudadService
    {
        Task<List<CiudadDto>> GetAllCiudades();
        Task<CiudadDto> GetCiudadById(int? Id);
        Task<ResultdoApi> InsertCiudad(CiudadDto objeto);
        Task<ResultdoApi> UpdateCiudad(CiudadDto objeto);
        Task<ResultdoApi> DeleteCiudad(int? Id);
    }
}
