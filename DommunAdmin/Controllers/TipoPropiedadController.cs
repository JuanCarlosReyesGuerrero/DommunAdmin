using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class TipoPropiedadController : Controller
    {
        private readonly ITipoPropiedadService inmobiliariaService;
        private readonly ICommonServices commonServices;

        public TipoPropiedadController(ITipoPropiedadService _inmobiliariaService, ICommonServices _commonServices)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<TipoPropiedadDto> list = await inmobiliariaService.GetAllTipoPropiedades();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoPropiedadDto model = new TipoPropiedadDto();

            if (id.HasValue && id != 0)
            {
                model = await inmobiliariaService.GetTipoPropiedadById(id);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            TipoPropiedadDto model = new TipoPropiedadDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoPropiedadDto model)
        {
            ResultdoApi vTemp = new ResultdoApi();

            try
            {
                vTemp = await inmobiliariaService.InsertTipoPropiedad(model);

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
            TipoPropiedadDto model = new TipoPropiedadDto();

            model = await inmobiliariaService.GetTipoPropiedadById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, TipoPropiedadDto model)
        {
            ResultdoApi vTemp = new ResultdoApi();

            try
            {
                TipoPropiedadDto Entity = await inmobiliariaService.GetTipoPropiedadById(id);

                if (Entity != null)
                {
                    vTemp = await inmobiliariaService.UpdateTipoPropiedad(model);
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
            TipoPropiedadDto model = new TipoPropiedadDto();

            model = await inmobiliariaService.GetTipoPropiedadById(id);

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
