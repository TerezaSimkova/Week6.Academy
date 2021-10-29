using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week6.Academy.CORE.BusinessLayer;
using Week6.Academy.MVC.Mapping;
using Week6.Academy.MVC.Models;

namespace Week6.Academy.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;
        //costruttore
        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var menu = BL.GetAllMenu();

            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();

            foreach (var item in menu)
            {
                menuViewModel.Add(item.ToMenuViewModel());
            }

            return View(menuViewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var menu = BL.GetAllMenu().FirstOrDefault(m => m.Id == id);

            var menuViewModel = menu.ToMenuViewModel();

            return View(menuViewModel);

        }

        #region Create
        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "Ristoratore")]
        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenu();
                BL.InserisciNuovoMenu(menu);
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }
        #endregion
        #region Update
        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var menu = BL.GetAllMenu().Find(m => m.Id == id);
            var conversione = menu.ToMenuViewModel();
            return View(conversione);
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpPost]
        public IActionResult Update(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenu();
                BL.ModificaMenu(menu);
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }
        #endregion


        #region Delete
        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var menu = BL.GetAllMenu().Find(m => m.Id == id);
            var conversione = menu.ToMenuViewModel();
            return View(conversione);
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpPost]
        public IActionResult Delete(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenu();
                BL.EliminaMenu(menu);
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }
        #endregion
    }
}
