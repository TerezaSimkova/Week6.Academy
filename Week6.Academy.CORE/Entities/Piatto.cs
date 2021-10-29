using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Academy.CORE.Entities
{
    public class Piatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipo Tipologia { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Prezzo { get; set; }

        //FK -> TODO:FK public int? IdMenu -> non ho fatto la foreign key nullabile,faccio inserire anche menu ID
        public int IdMenu { get; set; }
        public Menu _Menu {get;set;}
    }

    public enum Tipo
    {
        Primo=1,
        Secondo =2,
        Contorno=3,
        Dolce=4
    }
}
