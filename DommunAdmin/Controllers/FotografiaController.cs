using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class FotografiaController : Controller
    {
        private readonly IFotografiaService inmobiliariaService;
        private readonly ICommonServices commonServices;

        public FotografiaController(IFotografiaService _inmobiliariaService, ICommonServices _commonServices)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<FotografiaDto> list = await inmobiliariaService.GetAllFotografias();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FotografiaDto model = new FotografiaDto();

            if (id.HasValue && id != 0)
            {
                model = await inmobiliariaService.GetFotografiaById(id);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            FotografiaDto model = new FotografiaDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FotografiaDto model)
        {
            ResultdoApi vTemp = new ResultdoApi();

            try
            {
                vTemp = await inmobiliariaService.InsertFotografia(model);

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
            FotografiaDto model = new FotografiaDto();

            model = await inmobiliariaService.GetFotografiaById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, FotografiaDto model)
        {
            ResultdoApi vTemp = new ResultdoApi();

            try
            {
                FotografiaDto Entity = await inmobiliariaService.GetFotografiaById(id);

                if (Entity != null)
                {
                    vTemp = await inmobiliariaService.UpdateFotografia(model);
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

        public async Task<ActionResult> Delete(int id)
        {
            FotografiaDto model = new FotografiaDto();

            model = await inmobiliariaService.GetFotografiaById(id);

            return View(model);
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
