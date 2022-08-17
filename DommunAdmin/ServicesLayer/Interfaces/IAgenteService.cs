using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IAgenteService
    {
        Task<List<AgenteDto>> GetAllAgentes();
        Task<AgenteDto> GetAgenteById(int? Id);
        Task<ResultdoApi> InsertAgente(AgenteDto objeto);
        Task<ResultdoApi> UpdateAgente(AgenteDto objeto);
        Task<ResultdoApi> DeleteAgente(int? Id);
    }
}
