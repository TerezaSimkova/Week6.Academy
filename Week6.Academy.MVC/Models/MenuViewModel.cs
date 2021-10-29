using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week6.Academy.MVC.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PiattiViewModel> Piatti { get; set; } = new List<PiattiViewModel>();
    }
}
