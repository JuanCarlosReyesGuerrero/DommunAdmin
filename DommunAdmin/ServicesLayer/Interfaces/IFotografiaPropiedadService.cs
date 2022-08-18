using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IFotografiaPropiedadService
    {
        Task<List<FotografiaPropiedadDto>> GetAllFotografiaPropiedades();
        Task<FotografiaPropiedadDto> GetFotografiaPropiedadById(int? Id);
        Task<ResultdoApi> InsertFotografiaPropiedad(FotografiaPropiedadDto objeto);
        Task<ResultdoApi> UpdateFotografiaPropiedad(FotografiaPropiedadDto objeto);
        Task<ResultdoApi> DeleteFotografiaPropiedad(int? Id);
    }
}
