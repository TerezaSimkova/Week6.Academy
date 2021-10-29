using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week6.Academy.CORE.BusinessLayer;
using Week6.Academy.MVC.Mapping;
using Week6.Academy.MVC.Models;

namespace Week6.Academy.MVC.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IBusinessLayer BL;
        //costruttore
        public PiattiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Index()
        {
            var piatti = BL.GetAllPiatti();

            List<PiattiViewModel> piattiViewModel = new List<PiattiViewModel>();

            foreach (var item in piatti)
            {
                piattiViewModel.Add(item.ToPiattiViewModel());
            }

            return View(piattiViewModel);
        }

        #region Create
        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "Ristoratore")]
        public IActionResult Create(PiattiViewModel piattiViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattiViewModel.ToPiatto();
                BL.InserisciNuovoPiatto(piatto);
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(piattiViewModel);
        }
        #endregion

        #region Update
        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            LoadViewBag();
            var piatto = BL.GetAllPiatti().Find(p => p.Id == id);
            var conversione = piatto.ToPiattiViewModel();
            return View(conversione);
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpPost]
        public IActionResult Update(PiattiViewModel piattiViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattiViewModel.ToPiatto();
                BL.ModificaPiatto(piatto);
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(piattiViewModel);
        }
        #endregion


        #region Delete
        [Authorize(Policy = "Ristoratore")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            LoadViewBag();
            var piatto = BL.GetAllPiatti().Find(p => p.Id == id);
            var conversione = piatto.ToPiattiViewModel();
            return View(conversione);
        }
        [Authorize(Policy = "Ristoratore")]
        [HttpPost]
        public IActionResult Delete(PiattiViewModel piattiViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattiViewModel.ToPiatto();
                BL.EliminaPiatto(piatto);
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(piattiViewModel);
        }
        #endregion

        private void LoadViewBag()
        {
            ViewBag.Tipologia = new SelectList(new[]{
                new { Value=1, Text="Primo"},
                new { Value=2, Text="Secondo"},
                new { Value=3, Text="Contorno"},
                new { Value=4, Text="Dolce"} }.OrderBy(x => x.Text), "Value", "Text");
        }
    }
}
