using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class NumeroHabitacionController : Controller
    {
        private readonly INumeroHabitacionService numeroHabitacionService;        
        private readonly ICommonServices commonServices;

        public NumeroHabitacionController(INumeroHabitacionService _numeroHabitacionService, ICommonServices _commonServices)
        {
            this.numeroHabitacionService = _numeroHabitacionService;            
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<NumeroHabitacionDto> list = await numeroHabitacionService.GetAllNumeroHabitaciones();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NumeroHabitacionDto model = new NumeroHabitacionDto();

            if (id.HasValue && id != 0)
            {
                model = await numeroHabitacionService.GetNumeroHabitacionById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            NumeroHabitacionDto model = new NumeroHabitacionDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NumeroHabitacionDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await numeroHabitacionService.InsertNumeroHabitacion(model);

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

            NumeroHabitacionDto model = new NumeroHabitacionDto();

            model = await numeroHabitacionService.GetNumeroHabitacionById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, NumeroHabitacionDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                NumeroHabitacionDto Entity = await numeroHabitacionService.GetNumeroHabitacionById(id);

                if (Entity != null)
                {
                    vTemp = await numeroHabitacionService.UpdateNumeroHabitacion(model);
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
