using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Persistence.EntityConfigurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable(nameof(Pet));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Raca)
                .HasMaxLength(64);

            builder.Property(e => e.Comentário)
                .HasMaxLength(512);

            builder.Property(e => e.Especie)
                .HasMaxLength(64);

            builder.Property(e => e.UrlImagem)
                .HasMaxLength(256);

            builder.HasOne(e => e.GeneroPet)
                .WithMany(p => p.Pets)
                .HasForeignKey(e => e.IdGeneroPet);

            builder.HasOne(e => e.Usuario)
                .WithMany(p => p.Pets)
                .HasForeignKey(e => e.IdUsuario);
        }
    }
}
