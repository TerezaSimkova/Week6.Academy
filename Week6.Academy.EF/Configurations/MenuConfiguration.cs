using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week6.Academy.CORE;

namespace Week6.Academy.EF
{
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).IsRequired();

            //FK

            builder.HasMany(m => m.Piatti).WithOne(m => m._Menu).HasForeignKey(m => m.IdMenu);
        }
    }
}