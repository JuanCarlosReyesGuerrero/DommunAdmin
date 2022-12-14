using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class TipoOfertaController : Controller
    {
        private readonly ITipoOfertaService inmobiliariaService;
        private readonly ICommonServices commonServices;

        public TipoOfertaController(ITipoOfertaService _inmobiliariaService, ICommonServices _commonServices)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<TipoOfertaDto> list = await inmobiliariaService.GetAllTipoOfertas();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoOfertaDto model = new TipoOfertaDto();

            if (id.HasValue && id != 0)
            {
                model = await inmobiliariaService.GetTipoOfertaById(id);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            TipoOfertaDto model = new TipoOfertaDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoOfertaDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await inmobiliariaService.InsertTipoOferta(model);

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
            TipoOfertaDto model = new TipoOfertaDto();

            model = await inmobiliariaService.GetTipoOfertaById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, TipoOfertaDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                TipoOfertaDto Entity = await inmobiliariaService.GetTipoOfertaById(id);

                if (Entity != null)
                {
                    vTemp = await inmobiliariaService.UpdateTipoOferta(model);
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
            TipoOfertaDto model = new TipoOfertaDto();

            model = await inmobiliariaService.GetTipoOfertaById(id);

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
