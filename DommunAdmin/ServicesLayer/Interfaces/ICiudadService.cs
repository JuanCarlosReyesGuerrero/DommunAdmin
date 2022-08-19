using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ICiudadService
    {
        Task<List<CiudadDto>> GetAllCiudades();
        Task<CiudadDto> GetCiudadById(int? Id);
        Task<ResultadoApi> InsertCiudad(CiudadDto objeto);
        Task<ResultadoApi> UpdateCiudad(CiudadDto objeto);
        Task<ResultadoApi> DeleteCiudad(int? Id);
    }
}
