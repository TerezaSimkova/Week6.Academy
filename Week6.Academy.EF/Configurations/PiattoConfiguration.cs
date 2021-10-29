using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week6.Academy.CORE.Entities;

namespace Week6.Academy.EF
{
    internal class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Descrizione).IsRequired();
            builder.Property(p => p.Prezzo).IsRequired();
            builder.Property(p => p.Tipologia).IsRequired();

            //FK

            builder.HasOne(p => p._Menu).WithMany(p => p.Piatti).HasForeignKey(p => p.IdMenu);
        }
    }
}