using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IServiceApi
    {
        Task<List<AgenteDto>> Lista();
        Task<AgenteDto> GetAgenteById(int? Id);
        Task<bool> InsertAgente(AgenteDto objeto);
        Task<bool> UpdateAgente(AgenteDto objeto);
        Task<bool> DeleteAgente(int? Id);
    }
}
