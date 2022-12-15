using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class TipoParqueaderoController : Controller
    {
        private readonly ITipoParqueaderoService tipoParqueaderoService;
        private readonly ICommonServices commonServices;

        public TipoParqueaderoController(ITipoParqueaderoService _tipoParqueaderoService, ICommonServices _commonServices)
        {
            this.tipoParqueaderoService = _tipoParqueaderoService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<TipoParqueaderoDto> list = await tipoParqueaderoService.GetAllTipoParqueaderos();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoParqueaderoDto model = new TipoParqueaderoDto();

            if (id.HasValue && id != 0)
            {
                model = await tipoParqueaderoService.GetTipoParqueaderoById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();
                        
            TipoParqueaderoDto model = new TipoParqueaderoDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoParqueaderoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await tipoParqueaderoService.InsertTipoParqueadero(model);

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

            TipoParqueaderoDto model = new TipoParqueaderoDto();

            model = await tipoParqueaderoService.GetTipoParqueaderoById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, TipoParqueaderoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                TipoParqueaderoDto Entity = await tipoParqueaderoService.GetTipoParqueaderoById(id);

                if (Entity != null)
                {
                    vTemp = await tipoParqueaderoService.UpdateTipoParqueadero(model);
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
