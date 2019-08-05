using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Persistence.EntityConfigurations
{
    public class SituacaoSolicitacaoPetConfiguration : IEntityTypeConfiguration<SituacaoSolicitacaoPet>
    {
        public void Configure(EntityTypeBuilder<SituacaoSolicitacaoPet> builder)
        {
            builder.ToTable(nameof(SituacaoSolicitacaoPet));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
