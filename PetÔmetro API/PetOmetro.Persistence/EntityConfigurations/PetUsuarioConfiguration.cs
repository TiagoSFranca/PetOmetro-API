using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Persistence.EntityConfigurations
{
    public class PetUsuarioConfiguration : IEntityTypeConfiguration<PetUsuario>
    {
        public void Configure(EntityTypeBuilder<PetUsuario> builder)
        {
            builder.ToTable(nameof(PetUsuario));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.IdPet)
                .IsRequired();

            builder.HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.IdUsuario);

            builder.HasOne(e => e.Pet)
                .WithMany(p => p.PetUsuarios)
                .HasForeignKey(e => e.IdPet)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
