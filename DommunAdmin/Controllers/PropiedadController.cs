using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class PropiedadController : Controller
    {
        private readonly IPropiedadService inmobiliariaService;
        private readonly ICommonServices commonServices;
        private readonly ICiudadService ciudadService;
        private readonly IEstadoPropiedadService estadoPropiedadService;
        private readonly IAgenteService agenteService;
        private readonly ITipoPropiedadService tipoPropiedadService;

        public PropiedadController(
            IPropiedadService _inmobiliariaService,
            ICommonServices _commonServices,
            IAgenteService _agenteService,
            ITipoPropiedadService _tipoPropiedadService,
            ICiudadService _ciudadService,
            IEstadoPropiedadService _estadoPropiedadService)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
            this.agenteService = _agenteService;
            this.tipoPropiedadService = _tipoPropiedadService;
            this.ciudadService = _ciudadService;
            this.estadoPropiedadService = _estadoPropiedadService;
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

        public async Task<ActionResult> CreateAsync()
        {
            List<SelectListItem> listAgente = new List<SelectListItem>();

            listAgente = await agenteService.GetSelectListItems();

            ViewBag.Agente = listAgente;


            List<SelectListItem> listTipoPropiedad = new List<SelectListItem>();

            listTipoPropiedad = await tipoPropiedadService.GetSelectListItems();

            ViewBag.TipoPropiedad = listTipoPropiedad;


            List<SelectListItem> listCiudad = new List<SelectListItem>();

            listCiudad = await ciudadService.GetSelectListItems();

            ViewBag.Ciudad = listCiudad;


            List<SelectListItem> listEstadoPropiedad = new List<SelectListItem>();

            listEstadoPropiedad = await estadoPropiedadService.GetSelectListItems();

            ViewBag.EstadoPropiedad = listEstadoPropiedad;



            PropiedadDto model = new PropiedadDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropiedadDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

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
            List<SelectListItem> listAgente = new List<SelectListItem>();

            listAgente = await agenteService.GetSelectListItems();

            ViewBag.Agente = listAgente;


            List<SelectListItem> listTipoPropiedad = new List<SelectListItem>();

            listTipoPropiedad = await tipoPropiedadService.GetSelectListItems();

            ViewBag.TipoPropiedad = listTipoPropiedad;


            List<SelectListItem> listCiudad = new List<SelectListItem>();

            listCiudad = await ciudadService.GetSelectListItems();

            ViewBag.Ciudad = listCiudad;


            List<SelectListItem> listEstadoPropiedad = new List<SelectListItem>();

            listEstadoPropiedad = await estadoPropiedadService.GetSelectListItems();

            ViewBag.EstadoPropiedad = listEstadoPropiedad;


            PropiedadDto model = new PropiedadDto();

            model = await inmobiliariaService.GetPropiedadById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, PropiedadDto model)
        {
            ResultadoApi vTemp = new ResultadoApi();

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
