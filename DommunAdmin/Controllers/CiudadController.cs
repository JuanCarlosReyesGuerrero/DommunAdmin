using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class CiudadController : Controller
    {
        private readonly ICiudadService inmobiliariaService;
        private readonly ICommonServices commonServices;

        public CiudadController(ICiudadService _inmobiliariaService, ICommonServices _commonServices)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<CiudadDto> list = await inmobiliariaService.GetAllCiudads();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CiudadDto model = new CiudadDto();

            if (id.HasValue && id != 0)
            {
                model = await inmobiliariaService.GetCiudadById(id);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            CiudadDto model = new CiudadDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CiudadDto model)
        {
            ResultdoApi vTemp = new ResultdoApi();

            try
            {
                vTemp = await inmobiliariaService.InsertCiudad(model);

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
            CiudadDto model = new CiudadDto();

            model = await inmobiliariaService.GetCiudadById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, CiudadDto model)
        {
            ResultdoApi vTemp = new ResultdoApi();

            try
            {
                CiudadDto Entity = await inmobiliariaService.GetCiudadById(id);

                if (Entity != null)
                {
                    vTemp = await inmobiliariaService.UpdateCiudad(model);
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
            CiudadDto model = new CiudadDto();

            model = await inmobiliariaService.GetCiudadById(id);

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
