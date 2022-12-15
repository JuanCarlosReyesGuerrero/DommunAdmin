using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class EstratoController : Controller
    {
        private readonly IEstratoService estratoService;
        private readonly ICommonServices commonServices;

        public EstratoController(IEstratoService _estratoService, ICommonServices _commonServices)
        {
            this.estratoService = _estratoService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<EstratoDto> list = await estratoService.GetAllEstratos();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EstratoDto model = new EstratoDto();

            if (id.HasValue && id != 0)
            {
                model = await estratoService.GetEstratoById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            EstratoDto model = new EstratoDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstratoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await estratoService.InsertEstrato(model);

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

            EstratoDto model = new EstratoDto();

            model = await estratoService.GetEstratoById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, EstratoDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                EstratoDto Entity = await estratoService.GetEstratoById(id);

                if (Entity != null)
                {
                    vTemp = await estratoService.UpdateEstrato(model);
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
