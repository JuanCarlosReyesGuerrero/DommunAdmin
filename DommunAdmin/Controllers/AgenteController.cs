using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DommunAdmin.Controllers
{
    public class AgenteController : Controller
    {
        private readonly IAgenteService agenteService;
        private readonly IInmobiliariaService inmobiliariaService;

        public AgenteController(IAgenteService _agenteService, IInmobiliariaService _inmobiliariaService)
        {
            this.agenteService = _agenteService;
            this.inmobiliariaService = _inmobiliariaService;
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
        public ActionResult Create(IFormCollection collection)
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
