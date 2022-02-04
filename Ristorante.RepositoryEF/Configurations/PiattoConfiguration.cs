using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Core.Entities;

namespace Ristorante.RepositoryEF
{
    internal class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatto");
            builder.HasKey(p => p.IdPiatto);
            builder.HasIndex(p => p.IdPiatto).IsUnique();
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Prezzo).IsRequired();

            // relazione piatto : menu
            builder.HasOne(p => p.Menu).WithMany(m => m.Piatti).
                HasForeignKey(p => p.IdMenu);
        }
    }
}