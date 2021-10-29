using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week6.Academy.CORE;
using Week6.Academy.CORE.Entities;
using Week6.Academy.MVC.Models;
using Role = Week6.Academy.MVC.Models.Role;

namespace Week6.Academy.MVC.Mapping
{
    public static class Mapping
    {
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            List<PiattiViewModel> piattiViewModel = new List<PiattiViewModel>();
            foreach (var item in menu.Piatti)
            {
                piattiViewModel.Add(item?.ToPiattiViewModel());
            }

            return new MenuViewModel
            {
                Id = menu.Id,
                Nome = menu.Nome,
                Piatti = piattiViewModel
            };
        }

        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            List<Piatto> piatti = new List<Piatto>();
            foreach (var item in menuViewModel.Piatti)
            {
                piatti.Add(item?.ToPiatto());
            }

            return new Menu
            {
                Id = menuViewModel.Id,
                Nome = menuViewModel.Nome,
                Piatti = piatti
            };
        }

        public static PiattiViewModel ToPiattiViewModel(this Piatto piatto)
        {
            return new PiattiViewModel
            {
                Id = piatto.Id,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Tipologia = (PiattiViewModel.Tipo)piatto.Tipologia,
                Prezzo = piatto.Prezzo,
                IdMenu=piatto.IdMenu
            };
        }

        public static Piatto ToPiatto(this PiattiViewModel piattiViewModel)
        {
            return new Piatto
            {
                Id = piattiViewModel.Id,
                Nome = piattiViewModel.Nome,
                Descrizione = piattiViewModel.Descrizione,
                Tipologia = (Tipo)piattiViewModel.Tipologia,
                Prezzo = piattiViewModel.Prezzo,
                IdMenu = piattiViewModel.IdMenu
            };
        }
        public static Utente ToUtente(this UtenteLoginViewModel utenteViewModel)
        {

            return new Utente
            {
                Username = utenteViewModel.Username,
                Password = utenteViewModel.Password,
                Ruolo = (CORE.Entities.Role)utenteViewModel.Ruolo

            };
        }

        public static UtenteLoginViewModel ToUtenteViewModel(this Utente utente)
        {
            return new UtenteLoginViewModel
            {
                Username = utente.Username,
                Password = utente.Password,
                Ruolo = (Role)utente.Ruolo

            };
        }
    }
}
