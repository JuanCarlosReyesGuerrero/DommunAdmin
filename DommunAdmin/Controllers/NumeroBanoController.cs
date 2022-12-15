using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class NumeroBanoController : Controller
    {
        private readonly INumeroBanoService numeroBanoService;
        private readonly ICommonServices commonServices;

        public NumeroBanoController(INumeroBanoService _numeroBanoService, ICommonServices _commonServices)
        {
            this.numeroBanoService = _numeroBanoService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<NumeroBanoDto> list = await numeroBanoService.GetAllNumeroBanos();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NumeroBanoDto model = new NumeroBanoDto();

            if (id.HasValue && id != 0)
            {
                model = await numeroBanoService.GetNumeroBanoById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            NumeroBanoDto model = new NumeroBanoDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NumeroBanoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await numeroBanoService.InsertNumeroBano(model);

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

            NumeroBanoDto model = new NumeroBanoDto();

            model = await numeroBanoService.GetNumeroBanoById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, NumeroBanoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                NumeroBanoDto Entity = await numeroBanoService.GetNumeroBanoById(id);

                if (Entity != null)
                {
                    vTemp = await numeroBanoService.UpdateNumeroBano(model);
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
