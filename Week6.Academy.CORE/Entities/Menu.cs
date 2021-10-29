using System;
using System.Collections.Generic;
using Week6.Academy.CORE.Entities;

namespace Week6.Academy.CORE
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Piatto> Piatti { get; set; } = new List<Piatto>();
    }
}
