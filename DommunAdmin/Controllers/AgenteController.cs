using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class AgenteController : Controller
    {
        private readonly IAgenteService agenteService;
        private readonly IInmobiliariaService inmobiliariaService;
        private readonly ICommonServices commonServices;

        public AgenteController(IAgenteService _agenteService, IInmobiliariaService _inmobiliariaService, ICommonServices _commonServices)
        {
            this.agenteService = _agenteService;
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<AgenteDto> list = await agenteService.GetAllAgentes();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AgenteDto model = new AgenteDto();

            if (id.HasValue && id != 0)
            {
                model = await agenteService.GetAgenteById(id);
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            List<SelectListItem> listInmobiliaria = new List<SelectListItem>();

            listInmobiliaria = await inmobiliariaService.GetSelectListItems();

            ViewBag.Inmobiliaria = listInmobiliaria;

            AgenteDto model = new AgenteDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgenteDto model, IFormFile files)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                model.Foto= files;

                vTemp = await agenteService.InsertAgente(model);

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

            listInmobiliaria = await inmobiliariaService.GetSelectListItems();

            ViewBag.Inmobiliaria = listInmobiliaria;

            AgenteDto model = new AgenteDto();

            model = await agenteService.GetAgenteById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, AgenteDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                AgenteDto Entity = await agenteService.GetAgenteById(id);

                if (Entity != null)
                {
                    vTemp = await agenteService.UpdateAgente(model);
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
