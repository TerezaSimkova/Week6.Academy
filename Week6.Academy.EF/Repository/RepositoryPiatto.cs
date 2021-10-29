using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Academy.CORE.Entities;
using Week6.Academy.CORE.Interfaces;

namespace Week6.Academy.EF.Repository
{
    public class RepositoryPiatto : IRepositoryPiatto
    {
        private readonly RistoranteContext rcx;

        public RepositoryPiatto()
        {
            rcx = new RistoranteContext();
        }
        public Piatto Add(Piatto piatto)
        {
            rcx.Piatti.Add(piatto);
            rcx.SaveChanges();
            return piatto;
        }

        public bool Delete(Piatto piatto)
        {
            rcx.Piatti.Remove(piatto);
            rcx.SaveChanges();
            return true;
        }

        public List<Piatto> GetAll()
        {
            return rcx.Piatti.ToList();
        }

        public Piatto Update(Piatto piatto)
        {
            var oldPiatto = rcx.Piatti.FirstOrDefault(m => m.Id == piatto.Id);
            oldPiatto.Nome = piatto.Nome;
            oldPiatto.Prezzo = piatto.Prezzo;
            oldPiatto.Descrizione = piatto.Descrizione;
            oldPiatto.Tipologia = piatto.Tipologia;
            oldPiatto.IdMenu = piatto.IdMenu;
            rcx.SaveChanges();
            return piatto;
        }
    }
}
