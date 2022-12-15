using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class CaracteristicaPropiedadController : Controller
    {
        private readonly ICaracteristicaPropiedadService caracteristicaPropiedadService;
        private readonly ICommonServices commonServices;

        public CaracteristicaPropiedadController(ICaracteristicaPropiedadService _caracteristicaPropiedadService, ICommonServices _commonServices)
        {
            this.caracteristicaPropiedadService = _caracteristicaPropiedadService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<CaracteristicaPropiedadDto> list = await caracteristicaPropiedadService.GetAllCaracteristicaPropiedades();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CaracteristicaPropiedadDto model = new CaracteristicaPropiedadDto();

            if (id.HasValue && id != 0)
            {
                model = await caracteristicaPropiedadService.GetCaracteristicaPropiedadById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            CaracteristicaPropiedadDto model = new CaracteristicaPropiedadDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CaracteristicaPropiedadDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await caracteristicaPropiedadService.InsertCaracteristicaPropiedad(model);

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

            CaracteristicaPropiedadDto model = new CaracteristicaPropiedadDto();

            model = await caracteristicaPropiedadService.GetCaracteristicaPropiedadById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, CaracteristicaPropiedadDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                CaracteristicaPropiedadDto Entity = await caracteristicaPropiedadService.GetCaracteristicaPropiedadById(id);

                if (Entity != null)
                {
                    vTemp = await caracteristicaPropiedadService.UpdateCaracteristicaPropiedad(model);
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
