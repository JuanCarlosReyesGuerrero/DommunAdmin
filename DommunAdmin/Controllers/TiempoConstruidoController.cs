using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class TiempoConstruidoController : Controller
    {
        private readonly ITiempoConstruidoService tiempoConstruidoService;
        private readonly ICommonServices commonServices;

        public TiempoConstruidoController(ITiempoConstruidoService _tiempoConstruidoService, ICommonServices _commonServices)
        {
            this.tiempoConstruidoService = _tiempoConstruidoService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<TiempoConstruidoDto> list = await tiempoConstruidoService.GetAllTiempoConstruidos();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TiempoConstruidoDto model = new TiempoConstruidoDto();

            if (id.HasValue && id != 0)
            {
                model = await tiempoConstruidoService.GetTiempoConstruidoById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            TiempoConstruidoDto model = new TiempoConstruidoDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TiempoConstruidoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await tiempoConstruidoService.InsertTiempoConstruido(model);

                if (vTemp.Success)
                    TempData["Mensaje"] = commonServices.ShowAlert(Alerts.Success, vTemp.Message);
                else
                    TempData["Mensaje"] = commonServices.ShowAlert(Alerts.Danger, vTemp.Message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            TiempoConstruidoDto model = new TiempoConstruidoDto();

            model = await tiempoConstruidoService.GetTiempoConstruidoById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, TiempoConstruidoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                TiempoConstruidoDto Entity = await tiempoConstruidoService.GetTiempoConstruidoById(id);

                if (Entity != null)
                {
                    vTemp = await tiempoConstruidoService.UpdateTiempoConstruido(model);
                }


                if (vTemp.Success)
                    TempData["Mensaje"] = commonServices.ShowAlert(Alerts.Success, vTemp.Message);
                else
                    TempData["Mensaje"] = commonServices.ShowAlert(Alerts.Danger, vTemp.Message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
