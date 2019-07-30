using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Persistence.EntityConfigurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.Sobrenome)
                .HasMaxLength(64);

            builder.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Senha)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256);

        }
    }
}
