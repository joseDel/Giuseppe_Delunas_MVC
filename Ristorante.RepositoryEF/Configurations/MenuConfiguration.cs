using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Core.Entities;

namespace Ristorante.RepositoryEF
{
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.IdMenu);
            builder.HasIndex(p => p.IdMenu).IsUnique();
            builder.Property(m => m.Nome).IsRequired();

            // relazione menu : piatto
            builder.HasMany(m => m.Piatti).WithOne(p => p.Menu).
                HasForeignKey(p => p.IdMenu);
        }
    }
}