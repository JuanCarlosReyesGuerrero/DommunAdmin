using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DommunAdmin.Controllers
{   
    public class BlobStorageController : Controller
    {
        private readonly IBlobStorageService _blobStorage;        

        public BlobStorageController(IBlobStorageService blobStorage)
        {
            _blobStorage = blobStorage;            
        }

        public async Task<IActionResult> Index()
        {
            return View(await _blobStorage.GetAllBlobFiles());
        }       

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(AgenteDto sss, IFormFile files)
        {
            await _blobStorage.UploadBlobFileAsync(files);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string blobName)
        {
            await _blobStorage.DeleteDocumentAsync(blobName);
            return RedirectToAction("Index", "Home");
        }
    }
}
