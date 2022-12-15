using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class CaracteristicaController : Controller
    {
        private readonly ICaracteristicaService caracteristicaService;
        private readonly ICommonServices commonServices;

        public CaracteristicaController(ICaracteristicaService _caracteristicaService, ICommonServices _commonServices)
        {
            this.caracteristicaService = _caracteristicaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<CaracteristicaDto> list = await caracteristicaService.GetAllCaracteristicas();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CaracteristicaDto model = new CaracteristicaDto();

            if (id.HasValue && id != 0)
            {
                model = await caracteristicaService.GetCaracteristicaById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            CaracteristicaDto model = new CaracteristicaDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CaracteristicaDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await caracteristicaService.InsertCaracteristica(model);

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

            CaracteristicaDto model = new CaracteristicaDto();

            model = await caracteristicaService.GetCaracteristicaById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, CaracteristicaDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                CaracteristicaDto Entity = await caracteristicaService.GetCaracteristicaById(id);

                if (Entity != null)
                {
                    vTemp = await caracteristicaService.UpdateCaracteristica(model);
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
