using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Week6.Academy.CORE.BusinessLayer;
using Week6.Academy.MVC.Mapping;
using Week6.Academy.MVC.Models;

namespace Week6.Academy.MVC.Controllers
{
    public class UtentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public UtentiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UtenteLoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync(UtenteLoginViewModel utenteLoginViewModel)
        {
            if (utenteLoginViewModel == null)
            {
                return View();
            }

            var utente = BL.GetAccount(utenteLoginViewModel.Username);
            if (utente != null && ModelState.IsValid)
            {
                if (utente.Password == utenteLoginViewModel.Password)
                {

                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utente.Nome),
                        new Claim(ClaimTypes.Role, utente.Ruolo.ToString())
                    };

                    var properties = new AuthenticationProperties()
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                        RedirectUri = utenteLoginViewModel.ReturnUrl,
                    };

                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );

                    return Redirect("/");

                }
                else
                {
                    ModelState.AddModelError(nameof(utenteLoginViewModel.Password), "Password errata!");
                    return View(utenteLoginViewModel);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UtenteLoginViewModel utenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var utenteRegister = utenteViewModel.ToUtente();
                BL.InserisciNuovoUtente(utenteRegister);
                return Redirect("/");
            }
            return View(utenteViewModel);
        }


        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Forbidden() => View();
        //{
        //    return View();
        //}
    }
}

