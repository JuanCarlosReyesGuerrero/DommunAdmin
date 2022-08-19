using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class EstadoPropiedadController : Controller
    {
        private readonly IEstadoPropiedadService inmobiliariaService;
        private readonly ICommonServices commonServices;

        public EstadoPropiedadController(IEstadoPropiedadService _inmobiliariaService, ICommonServices _commonServices)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<EstadoPropiedadDto> list = await inmobiliariaService.GetAllEstadoPropiedades();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EstadoPropiedadDto model = new EstadoPropiedadDto();

            if (id.HasValue && id != 0)
            {
                model = await inmobiliariaService.GetEstadoPropiedadById(id);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            EstadoPropiedadDto model = new EstadoPropiedadDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstadoPropiedadDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                vTemp = await inmobiliariaService.InsertEstadoPropiedad(model);

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
            EstadoPropiedadDto model = new EstadoPropiedadDto();

            model = await inmobiliariaService.GetEstadoPropiedadById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, EstadoPropiedadDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

            try
            {
                EstadoPropiedadDto Entity = await inmobiliariaService.GetEstadoPropiedadById(id);

                if (Entity != null)
                {
                    vTemp = await inmobiliariaService.UpdateEstadoPropiedad(model);
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
            EstadoPropiedadDto model = new EstadoPropiedadDto();

            model = await inmobiliariaService.GetEstadoPropiedadById(id);

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
