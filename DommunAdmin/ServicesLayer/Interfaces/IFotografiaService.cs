using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IFotografiaService
    {
        Task<List<FotografiaDto>> GetAllFotografias();
        Task<FotografiaDto> GetFotografiaById(int? Id);
        Task<ResultadoApi> InsertFotografia(FotografiaDto objeto);
        Task<ResultadoApi> UpdateFotografia(FotografiaDto objeto);
        Task<ResultadoApi> DeleteFotografia(int? Id);
    }
}
