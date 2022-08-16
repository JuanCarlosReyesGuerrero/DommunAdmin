using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IAgenteService
    {
        Task<List<AgenteDto>> GetAllAgentes();
        Task<AgenteDto> GetAgenteById(int? Id);
        Task<bool> InsertAgente(AgenteDto objeto);
        Task<bool> UpdateAgente(AgenteDto objeto);
        Task<bool> DeleteAgente(int? Id);
    }
}
