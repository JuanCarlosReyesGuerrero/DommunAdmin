using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IFotografiaPropiedadService
    {
        Task<List<FotografiaPropiedadDto>> GetAllFotografiaPropiedades();
        Task<FotografiaPropiedadDto> GetFotografiaPropiedadById(int? Id);
        Task<ResultadoApi> InsertFotografiaPropiedad(FotografiaPropiedadDto objeto);
        Task<ResultadoApi> UpdateFotografiaPropiedad(FotografiaPropiedadDto objeto);
        Task<ResultadoApi> DeleteFotografiaPropiedad(int? Id);
    }
}
