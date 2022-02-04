using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ristorante.Core.BusinessLayer;
using Ristorante.Core.Entities;
using Ristorante.MVC.Helper;
using Ristorante.MVC.Models;

namespace Ristorante.MVC.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IBusinessLayer BL;

        public PiattiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Piatto> piatti = BL.GetAllPiatti();
            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();
            foreach (var item in piatti)
            {
                piattiViewModel.Add(item.ToPiattoViewModel());
            }

            return View(piattiViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "Adm")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PiattoViewModel piattoVM)
        {
            if (ModelState.IsValid)
            {
                Piatto piatto = piattoVM.ToPiatto();
                Esito esito = BL.AggiungiPiatto(piatto);
                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            }
            return View(piattoVM);
        }

        [HttpGet]
        [Authorize(Policy = "Adm")]
        public IActionResult Edit(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.IdPiatto == id);
            var piattoViewModel = piatto.ToPiattoViewModel();

            return View(piattoViewModel);
        }

        [HttpPost]
        public IActionResult Edit(PiattoViewModel piattoVM)
        {
            if (ModelState.IsValid)
            {
                Piatto piatto = piattoVM.ToPiatto();
                var esito = BL.ModificaPiatto(piatto.IdPiatto, piatto.Prezzo);
                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            }
            return View(piattoVM);
        }

        [HttpGet]
        [Authorize(Policy = "Adm")]
        public IActionResult Delete(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.IdPiatto == id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            return View(piattoViewModel);
        }

        [HttpPost]
        public IActionResult Delete(PiattoViewModel piattoVM)
        {
            var piatto = piattoVM.ToPiatto();
            var esito = BL.EliminaPiatto(piatto.IdPiatto);
            if (esito.IsOk == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MessaggioErrore = esito.Messaggio;
                return View("ErroriDiBusiness");
            }
        }
    }
}
