using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Week6.Academy.CORE;

namespace Week6.Academy.MVC.Models
{
    public class PiattiViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipo Tipologia { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Prezzo { get; set; }
        //FK
        public int IdMenu { get; set; }
        public Menu Menu { get; set; }


        public enum Tipo
        {
            Primo = 1,
            Secondo = 2,
            Contorno = 3,
            Dolce = 4
        }
    }
}
