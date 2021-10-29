using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week6.Academy.CORE.Entities;

namespace Week6.Academy.EF
{
    internal class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utente");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Nome).IsRequired();
            builder.Property(s => s.Username).IsRequired();
            builder.Property(s => s.Password).IsRequired();
            builder.Property(s => s.Ruolo).IsRequired();
        }
    }
}