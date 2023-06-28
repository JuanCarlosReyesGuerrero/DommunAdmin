using DommunAdmin.Models;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface IBlobStorageService
    {
        Task<List<BlobStorage>> GetAllBlobFiles();
        Task UploadBlobFileAsync(IFormFile files);
        Task DeleteDocumentAsync(string blobName);
    }
}
