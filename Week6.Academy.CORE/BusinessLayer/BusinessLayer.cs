using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Academy.CORE.Entities;
using Week6.Academy.CORE.Interfaces;

namespace Week6.Academy.CORE.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {

        private readonly IRepositoryMenu menuRepo;
        private readonly IRepositoryPiatto piattiRepo;
        private readonly IRepositoryUtenti utentiRepo;


        public BusinessLayer(IRepositoryMenu menu, IRepositoryPiatto piatto , IRepositoryUtenti utenti)
        {
            menuRepo = menu;
            piattiRepo = piatto;
            utentiRepo = utenti;
        }

        public bool EliminaMenu(Menu menu)
        {
            return menuRepo.Delete(menu);
        }

        public bool EliminaPiatto(Piatto piatto)
        {
            return piattiRepo.Delete(piatto);
        }

        public Utente GetAccount(string username)
        {
            Utente u = utentiRepo.GetAccountByUsername(username);
            return u;
        }

        public List<Menu> GetAllMenu()
        {
            return menuRepo.GetAll();
        }

        public List<Piatto> GetAllPiatti()
        {
            return piattiRepo.GetAll();
        }

        public bool InserisciNuovoMenu(Menu menu)
        {
            Menu m = menuRepo.Add(menu);
            if (m == null)
            {
                return false;
            }
            return true;
        }

        public bool InserisciNuovoPiatto(Piatto piatto)
        {
            Piatto p = piattiRepo.Add(piatto);
            if (p == null)
            {
                return false;
            }
            return true;
        }

        public bool InserisciNuovoUtente(Utente utenteRegister)
        {
            Utente u = utentiRepo.Add(utenteRegister);
            if (u == null)
            {
                return false;
            }
            return true;
        }

        public Menu ModificaMenu(Menu menu)
        {
            Menu menuModificato = menuRepo.Update(menu);
            return menuModificato;
        }

        public Piatto ModificaPiatto(Piatto piatto)
        {
            Piatto piattoModificato = piattiRepo.Update(piatto);
            return piattoModificato;
        }
    }
}
