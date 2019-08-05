using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Persistence.EntityConfigurations
{
    public class SolicitacaoPetConfiguration : IEntityTypeConfiguration<SolicitacaoPet>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoPet> builder)
        {
            builder.ToTable(nameof(SolicitacaoPet));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DataSolicitacao)
                .IsRequired();

            builder.Property(e => e.Visualizado)
                .IsRequired();

            builder.HasOne(e => e.UsuarioSolicitante)
                .WithMany(p => p.SolicitacoesPetSolicitante)
                .HasForeignKey(e => e.IdUsuarioSolicitante)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.UsuarioSolicitado)
                .WithMany(p => p.SolicitacoesPetSolicitado)
                .HasForeignKey(e => e.IdUsuarioSolicitado)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Pet)
                .WithMany(p => p.SolicitacoesPet)
                .HasForeignKey(e => e.IdPet);

            builder.HasOne(e => e.SituacaoSolicitacao)
                .WithMany(p => p.SolicitacoesPet)
                .HasForeignKey(e => e.IdSituacaoSolicitacao);
        }
    }
}
