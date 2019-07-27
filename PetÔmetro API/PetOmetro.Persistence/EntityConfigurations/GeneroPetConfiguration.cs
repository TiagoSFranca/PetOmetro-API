using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOmetro.Domain.Domain;

namespace PetOmetro.Persistence.EntityConfigurations
{
    public class GeneroPetConfiguration : IEntityTypeConfiguration<GeneroPet>
    {
        public void Configure(EntityTypeBuilder<GeneroPet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
