using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IFotografiaService
    {
        Task<List<FotografiaDto>> GetAllFotografias();
        Task<FotografiaDto> GetFotografiaById(int? Id);
        Task<ResultdoApi> InsertFotografia(FotografiaDto objeto);
        Task<ResultdoApi> UpdateFotografia(FotografiaDto objeto);
        Task<ResultdoApi> DeleteFotografia(int? Id);
    }
}
