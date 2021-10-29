using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Academy.CORE.Entities;

namespace Week6.Academy.CORE.BusinessLayer
{
    public interface IBusinessLayer
    {
        #region Piatto
        List<Piatto> GetAllPiatti();
        public Utente GetAccount(string username);
        bool InserisciNuovoUtente(Utente utenteRegister);
        bool InserisciNuovoPiatto(Piatto piatto);
        public Piatto ModificaPiatto(Piatto piatto);
        bool EliminaPiatto(Piatto piatto);
        #endregion

        #region Menu
        List<Menu> GetAllMenu();
        bool InserisciNuovoMenu(Menu menu);
        public Menu ModificaMenu(Menu menu);
        bool EliminaMenu(Menu menu);
        #endregion

    }
}
