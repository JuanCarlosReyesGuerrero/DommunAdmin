﻿using DommunAdmin.Commons;
using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.Controllers
{
    public class InmobiliariaController : Controller
    {
        private readonly IInmobiliariaService inmobiliariaService;
        private readonly ICommonServices commonServices;

        public InmobiliariaController(IInmobiliariaService _inmobiliariaService, ICommonServices _commonServices)
        {
            this.inmobiliariaService = _inmobiliariaService;
            this.commonServices = _commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<InmobiliariaDto> list = await inmobiliariaService.GetAllInmobiliarias();

            return View(list);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InmobiliariaDto model = new InmobiliariaDto();

            if (id.HasValue && id != 0)
            {
                model = await inmobiliariaService.GetInmobiliariaById(id);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            InmobiliariaDto model = new InmobiliariaDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InmobiliariaDto model)
        {
            try
            {
                var vTemp = inmobiliariaService.InsertInmobiliaria(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            InmobiliariaDto model = new InmobiliariaDto();

            model = await inmobiliariaService.GetInmobiliariaById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int? id, InmobiliariaDto model)
        {
            bool vTemp = false;

            try
            {
                InmobiliariaDto Entity = await inmobiliariaService.GetInmobiliariaById(id);

                if (Entity != null)
                {
                    vTemp = await inmobiliariaService.UpdateInmobiliaria(model);
                }


                if (vTemp)               
                    TempData["Mensaje"] = commonServices.ShowAlert(Alerts.Success, Constantes.msGuardado);               
                else
                    TempData["Mensaje"] = commonServices.ShowAlert(Alerts.Danger, Constantes.msNoGuardado);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            InmobiliariaDto model = new InmobiliariaDto();

            model = await inmobiliariaService.GetInmobiliariaById(id);

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