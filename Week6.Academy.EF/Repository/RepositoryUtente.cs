using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Academy.CORE.Entities;
using Week6.Academy.CORE.Interfaces;

namespace Week6.Academy.EF.Repository
{
    public class RepositoryUtente : IRepositoryUtenti
    {
        private readonly RistoranteContext rcx;

        public RepositoryUtente()
        {
            rcx = new RistoranteContext();
        }
        public Utente Add(Utente utente)
        {
            rcx.Utenti.Add(utente);
            rcx.SaveChanges();
            return utente;
        }

        public bool Delete(Utente utente)
        {
            rcx.Utenti.Remove(utente);
            rcx.SaveChanges();
            return true;
        }

        public Utente GetAccountByUsername(string username)
        {
            Utente u = rcx.Utenti.FirstOrDefault(u => u.Username == username);
            return u;
        }

        public List<Utente> GetAll()
        {
            return rcx.Utenti.ToList();
        }

        public Utente Update(Utente utente)
        {
            var oldUtente = rcx.Utenti.FirstOrDefault(m => m.Id == utente.Id);
            oldUtente.Nome = utente.Nome;
            oldUtente.Username = utente.Username;
            oldUtente.Password = utente.Password;
            oldUtente.Ruolo = utente.Ruolo;
            rcx.SaveChanges();
            return utente;
        }
    }
}
