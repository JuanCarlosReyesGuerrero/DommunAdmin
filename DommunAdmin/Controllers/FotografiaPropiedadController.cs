using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class FotografiaPropiedadController : Controller
    {
        private readonly IFotografiaPropiedadService inmobiliariaService;
        private readonly ICommonServices commonServices;

        public FotografiaPropiedadController(IFotografiaPropiedadService _inmobiliariaService, ICommonServices _commonServices)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<FotografiaPropiedadDto> list = await inmobiliariaService.GetAllFotografiaPropiedades();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FotografiaPropiedadDto model = new FotografiaPropiedadDto();

            if (id.HasValue && id != 0)
            {
                model = await inmobiliariaService.GetFotografiaPropiedadById(id);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            FotografiaPropiedadDto model = new FotografiaPropiedadDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FotografiaPropiedadDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await inmobiliariaService.InsertFotografiaPropiedad(model);

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
            FotografiaPropiedadDto model = new FotografiaPropiedadDto();

            model = await inmobiliariaService.GetFotografiaPropiedadById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, FotografiaPropiedadDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                FotografiaPropiedadDto Entity = await inmobiliariaService.GetFotografiaPropiedadById(id);

                if (Entity != null)
                {
                    vTemp = await inmobiliariaService.UpdateFotografiaPropiedad(model);
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
            FotografiaPropiedadDto model = new FotografiaPropiedadDto();

            model = await inmobiliariaService.GetFotografiaPropiedadById(id);

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
