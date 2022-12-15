using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class NumeroParqueaderoController : Controller
    {
        private readonly INumeroParqueaderoService numeroParqueaderoService;
        private readonly ICommonServices commonServices;

        public NumeroParqueaderoController(INumeroParqueaderoService _numeroParqueaderoService, ICommonServices _commonServices)
        {
            this.numeroParqueaderoService = _numeroParqueaderoService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<NumeroParqueaderoDto> list = await numeroParqueaderoService.GetAllNumeroParqueaderos();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NumeroParqueaderoDto model = new NumeroParqueaderoDto();

            if (id.HasValue && id != 0)
            {
                model = await numeroParqueaderoService.GetNumeroParqueaderoById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            NumeroParqueaderoDto model = new NumeroParqueaderoDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NumeroParqueaderoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await numeroParqueaderoService.InsertNumeroParqueadero(model);

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

            NumeroParqueaderoDto model = new NumeroParqueaderoDto();

            model = await numeroParqueaderoService.GetNumeroParqueaderoById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, NumeroParqueaderoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                NumeroParqueaderoDto Entity = await numeroParqueaderoService.GetNumeroParqueaderoById(id);

                if (Entity != null)
                {
                    vTemp = await numeroParqueaderoService.UpdateNumeroParqueadero(model);
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
