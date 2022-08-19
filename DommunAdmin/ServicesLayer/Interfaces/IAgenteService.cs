using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IAgenteService
    {
        Task<List<AgenteDto>> GetAllAgentes();
        Task<AgenteDto> GetAgenteById(int? Id);
        Task<ResultadoApi> InsertAgente(AgenteDto objeto);
        Task<ResultadoApi> UpdateAgente(AgenteDto objeto);
        Task<ResultadoApi> DeleteAgente(int? Id);
    }
}
