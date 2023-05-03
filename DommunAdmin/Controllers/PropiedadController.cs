﻿using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using DommunAdmin.ServicesLayer.Services;
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
        private readonly ITipoOfertaService tipoOfertaService;
        private readonly IEstratoService estratoService;
        private readonly ITiempoConstruidoService tiempoConstruidoService;
        private readonly INumeroHabitacionService numeroHabitacionService;
        private readonly INumeroBanoService numeroBanoService;
        private readonly ITipoParqueaderoService tipoParqueaderoService;
        private readonly ICaracteristicaParqueaderoService caracteristicaParqueaderoService;
        private readonly INumeroParqueaderoService numeroParqueaderoService;

        public PropiedadController(
            IPropiedadService _inmobiliariaService,
            ICommonServices _commonServices,
            IAgenteService _agenteService,
            ITipoPropiedadService _tipoPropiedadService,
            ICiudadService _ciudadService,
            IEstadoPropiedadService _estadoPropiedadService,
            ITipoOfertaService _tipoOfertaService,
            IEstratoService _estratoService,
            ITiempoConstruidoService _tiempoConstruidoService,
            INumeroHabitacionService _numeroHabitacionService,
            INumeroBanoService _numeroBanoService,
            ITipoParqueaderoService _tipoParqueaderoService,
            ICaracteristicaParqueaderoService _caracteristicaParqueaderoService,
            INumeroParqueaderoService _numeroParqueaderoService)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
            this.agenteService = _agenteService;
            this.tipoPropiedadService = _tipoPropiedadService;
            this.ciudadService = _ciudadService;
            this.estadoPropiedadService = _estadoPropiedadService;
            this.tipoOfertaService = _tipoOfertaService;
            this.estratoService = _estratoService;
            this.tiempoConstruidoService = _tiempoConstruidoService;
            this.numeroHabitacionService = _numeroHabitacionService;
            this.numeroBanoService = _numeroBanoService;
            this.tipoParqueaderoService = _tipoParqueaderoService;
            this.caracteristicaParqueaderoService = _caracteristicaParqueaderoService;
            this.numeroParqueaderoService = _numeroParqueaderoService;
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


            List<SelectListItem> listTipoOferta = new List<SelectListItem>();
            listTipoOferta = await tipoOfertaService.GetSelectListItems();
            ViewBag.TipoOferta = listTipoOferta;


            List<SelectListItem> listEstrato = new List<SelectListItem>();
            listEstrato = await estratoService.GetSelectListItems();
            ViewBag.Estrato = listEstrato;

            List<SelectListItem> listTiempoConstruido = new List<SelectListItem>();
            listTiempoConstruido = await tiempoConstruidoService.GetSelectListItems();
            ViewBag.TiempoConstruido = listTiempoConstruido;

            List<SelectListItem> listNumeroHabitacion = new List<SelectListItem>();
            listNumeroHabitacion = await numeroHabitacionService.GetSelectListItems();
            ViewBag.NumeroHabitacion = listNumeroHabitacion;

            List<SelectListItem> listNumeroBano = new List<SelectListItem>();
            listNumeroBano = await numeroBanoService.GetSelectListItems();
            ViewBag.NumeroBano = listNumeroBano;

            List<SelectListItem> listNumeroParqueadero = new List<SelectListItem>();
            listNumeroParqueadero = await numeroParqueaderoService.GetSelectListItems();
            ViewBag.NumeroParqueadero = listNumeroParqueadero;

            List<SelectListItem> listTipoParqueadero = new List<SelectListItem>();
            listTipoParqueadero = await tipoParqueaderoService.GetSelectListItems();
            ViewBag.TipoParqueadero = listTipoParqueadero;

            List<SelectListItem> listCaracteristicaparqueadero = new List<SelectListItem>();
            listCaracteristicaparqueadero = await caracteristicaParqueaderoService.GetSelectListItems();
            ViewBag.Caracteristicaparqueadero = listCaracteristicaparqueadero;

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


            List<SelectListItem> listTipoOferta = new List<SelectListItem>();
            listTipoOferta = await tipoOfertaService.GetSelectListItems();
            ViewBag.TipoOferta = listTipoOferta;


            List<SelectListItem> listEstrato = new List<SelectListItem>();
            listEstrato = await estratoService.GetSelectListItems();
            ViewBag.Estrato = listEstrato;

            List<SelectListItem> listTiempoConstruido = new List<SelectListItem>();
            listTiempoConstruido = await tiempoConstruidoService.GetSelectListItems();
            ViewBag.TiempoConstruido = listTiempoConstruido;

            List<SelectListItem> listNumeroHabitacion = new List<SelectListItem>();
            listNumeroHabitacion = await numeroHabitacionService.GetSelectListItems();
            ViewBag.NumeroHabitacion = listNumeroHabitacion;

            List<SelectListItem> listNumeroBano = new List<SelectListItem>();
            listNumeroBano = await numeroBanoService.GetSelectListItems();
            ViewBag.NumeroBano = listNumeroBano;

            List<SelectListItem> listNumeroParqueadero = new List<SelectListItem>();
            listNumeroParqueadero = await numeroParqueaderoService.GetSelectListItems();
            ViewBag.NumeroParqueadero = listNumeroParqueadero;

            List<SelectListItem> listTipoParqueadero = new List<SelectListItem>();
            listTipoParqueadero = await tipoParqueaderoService.GetSelectListItems();
            ViewBag.TipoParqueadero = listTipoParqueadero;

            List<SelectListItem> listCaracteristicaparqueadero = new List<SelectListItem>();
            listCaracteristicaparqueadero = await caracteristicaParqueaderoService.GetSelectListItems();
            ViewBag.Caracteristicaparqueadero = listCaracteristicaparqueadero;


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
