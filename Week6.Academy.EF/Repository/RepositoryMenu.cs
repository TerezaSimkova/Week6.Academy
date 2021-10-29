using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Week6.Academy.CORE;
using Week6.Academy.CORE.Interfaces;

namespace Week6.Academy.EF
{
    public class RepositoryMenu : IRepositoryMenu
    {
        private readonly RistoranteContext rcx;

        public RepositoryMenu()
        {
            rcx = new RistoranteContext();
        }
        public Menu Add(Menu menu)
        {
            rcx.Menu.Add(menu);
            rcx.SaveChanges();
            return menu;
        }

        public bool Delete(Menu menu)
        {
            rcx.Menu.Remove(menu);
            rcx.SaveChanges();
            return true;
        }

        public List<Menu> GetAll()
        {
            return rcx.Menu.Include(p =>p.Piatti).ToList();
        }

        public Menu Update(Menu menu)
        {
            var oldMenu = rcx.Menu.FirstOrDefault(m => m.Id == menu.Id);
            oldMenu.Nome = menu.Nome;          
            rcx.SaveChanges();
            return menu;
        }
    }
}
