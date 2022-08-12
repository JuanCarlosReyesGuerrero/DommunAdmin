using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DommunAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAgenteService serviceApi;

        public HomeController(IAgenteService _serviceApi)
        {
            this.serviceApi = _serviceApi;
        }

        public async Task<IActionResult> Index()
        {
            List<AgenteDto> list = await serviceApi.Lista();

            return View(list);
        }

        public async Task<IActionResult> Agente(int Id)
        {
            AgenteDto model = new AgenteDto();

            ViewBag.Accion = "Nuevo producto";

            if (Id != 0)
            {
                model = await serviceApi.GetAgenteById(Id);
                ViewBag.Accion = "Editar producto";
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(AgenteDto objModel)
        {
            bool respuesta;

            if (objModel.id == 0)
            {
                respuesta = await serviceApi.InsertAgente(objModel);
            }
            else
            {
                respuesta=await serviceApi.UpdateAgente(objModel);
            }

            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var respuesta = await serviceApi.DeleteAgente(Id);

            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }










        //******************************************************************************************

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}