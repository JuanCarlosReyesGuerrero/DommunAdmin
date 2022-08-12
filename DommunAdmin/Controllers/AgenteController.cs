using DommunAdmin.Models;
using DommunAdmin.ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DommunAdmin.Controllers
{
    public class AgenteController : Controller
    {
        private readonly IAgenteService agenteService;

        public AgenteController(IAgenteService _agenteService)
        {
            this.agenteService = _agenteService;
        }

        public async Task<ActionResult> Index()
        {
            List<AgenteDto> list = await agenteService.Lista();

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

        public ActionResult Create()
        {
            return View();
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
