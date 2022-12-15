using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class CaracteristicaParqueaderoController : Controller
    {
        private readonly ICaracteristicaParqueaderoService caracteristicaParqueaderoService;
        private readonly ICommonServices commonServices;

        public CaracteristicaParqueaderoController(ICaracteristicaParqueaderoService _caracteristicaParqueaderoService, ICommonServices _commonServices)
        {
            this.caracteristicaParqueaderoService = _caracteristicaParqueaderoService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<CaracteristicaParqueaderoDto> list = await caracteristicaParqueaderoService.GetAllCaracteristicaParqueaderos();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CaracteristicaParqueaderoDto model = new CaracteristicaParqueaderoDto();

            if (id.HasValue && id != 0)
            {
                model = await caracteristicaParqueaderoService.GetCaracteristicaParqueaderoById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            CaracteristicaParqueaderoDto model = new CaracteristicaParqueaderoDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CaracteristicaParqueaderoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await caracteristicaParqueaderoService.InsertCaracteristicaParqueadero(model);

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

            CaracteristicaParqueaderoDto model = new CaracteristicaParqueaderoDto();

            model = await caracteristicaParqueaderoService.GetCaracteristicaParqueaderoById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, CaracteristicaParqueaderoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                CaracteristicaParqueaderoDto Entity = await caracteristicaParqueaderoService.GetCaracteristicaParqueaderoById(id);

                if (Entity != null)
                {
                    vTemp = await caracteristicaParqueaderoService.UpdateCaracteristicaParqueadero(model);
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
