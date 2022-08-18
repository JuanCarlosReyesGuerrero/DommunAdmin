using DomainLayer.Dtos;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class PropiedadController : Controller
    {
        private readonly IPropiedadService inmobiliariaService;
        private readonly ICommonServices commonServices;

        public PropiedadController(IPropiedadService _inmobiliariaService, ICommonServices _commonServices)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<PropiedadDto> list = await inmobiliariaService.GetAllPropiedades();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PropiedadDto model = new PropiedadDto();

            if (id.HasValue && id != 0)
            {
                model = await inmobiliariaService.GetPropiedadById(id);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            PropiedadDto model = new PropiedadDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropiedadDto model)
        {
            ResultdoApi vTemp = new ResultdoApi();

            try
            {
                vTemp = await inmobiliariaService.InsertPropiedad(model);

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
            PropiedadDto model = new PropiedadDto();

            model = await inmobiliariaService.GetPropiedadById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, PropiedadDto model)
        {
            ResultdoApi vTemp = new ResultdoApi();

            try
            {
                PropiedadDto Entity = await inmobiliariaService.GetPropiedadById(id);

                if (Entity != null)
                {
                    vTemp = await inmobiliariaService.UpdatePropiedad(model);
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
            PropiedadDto model = new PropiedadDto();

            model = await inmobiliariaService.GetPropiedadById(id);

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
