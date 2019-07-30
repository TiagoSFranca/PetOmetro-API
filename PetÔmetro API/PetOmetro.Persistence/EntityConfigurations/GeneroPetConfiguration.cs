using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Persistence.EntityConfigurations
{
    public class GeneroPetConfiguration : IEntityTypeConfiguration<GeneroPet>
    {
        public void Configure(EntityTypeBuilder<GeneroPet> builder)
        {
            builder.ToTable(nameof(GeneroPet));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
