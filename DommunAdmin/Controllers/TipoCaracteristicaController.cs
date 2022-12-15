using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class TipoCaracteristicaController : Controller
    {
        private readonly ITipoCaracteristicaService tipoCaracteristicaService;
        private readonly ICommonServices commonServices;

        public TipoCaracteristicaController(ITipoCaracteristicaService _tipoCaracteristicaService, ICommonServices _commonServices)
        {
            this.tipoCaracteristicaService = _tipoCaracteristicaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<TipoCaracteristicaDto> list = await tipoCaracteristicaService.GetAllTipoCaracteristicas();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoCaracteristicaDto model = new TipoCaracteristicaDto();

            if (id.HasValue && id != 0)
            {
                model = await tipoCaracteristicaService.GetTipoCaracteristicaById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            TipoCaracteristicaDto model = new TipoCaracteristicaDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoCaracteristicaDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await tipoCaracteristicaService.InsertTipoCaracteristica(model);

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

            TipoCaracteristicaDto model = new TipoCaracteristicaDto();

            model = await tipoCaracteristicaService.GetTipoCaracteristicaById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, TipoCaracteristicaDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                TipoCaracteristicaDto Entity = await tipoCaracteristicaService.GetTipoCaracteristicaById(id);

                if (Entity != null)
                {
                    vTemp = await tipoCaracteristicaService.UpdateTipoCaracteristica(model);
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
