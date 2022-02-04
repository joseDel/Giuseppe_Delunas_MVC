using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ristorante.Core.BusinessLayer;
using Ristorante.Core.Entities;
using Ristorante.MVC.Helper;
using Ristorante.MVC.Models;

namespace Ristorante.MVC.Controllers
{

    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;

        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Menu> menu = BL.GetAllMenu();
            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();
            foreach (var item in menu)
            {
                menuViewModel.Add(item.ToMenuViewModel());
            }

            return View(menuViewModel);
        }

        public IActionResult Details(int id)
        {
            var menu = BL.GetAllMenu().FirstOrDefault(m => m.IdMenu == id);

            var menuVM = menu.ToMenuViewModel();
            return View(menuVM);
        }

        [HttpGet]
        [Authorize(Policy = "Adm")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu menu = menuViewModel.ToMenu();
                Esito esito = BL.AggiungiMenu(menu);
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
            return View(menuViewModel);
        }
    }

}
