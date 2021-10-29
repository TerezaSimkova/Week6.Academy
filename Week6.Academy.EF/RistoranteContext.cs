using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Academy.CORE;
using Week6.Academy.CORE.Entities;

namespace Week6.Academy.EF
{
    public class RistoranteContext : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public RistoranteContext()
        {

        }

        public RistoranteContext(DbContextOptions<RistoranteContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		    Database=RistoranteDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Menu>(new MenuConfiguration());
            modelBuilder.ApplyConfiguration<Piatto>(new PiattoConfiguration());
            modelBuilder.ApplyConfiguration<Utente>(new UtenteConfiguration());
        }
    }
}
