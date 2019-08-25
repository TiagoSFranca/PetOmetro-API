using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Domain.Entities;
using PetOmetro.Identity.Models;

namespace PetOmetro.Persistence
{
    public class PetOmetroContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public PetOmetroContext(DbContextOptions<PetOmetroContext> options)
            : base(options)
        {
        }

        #region [Entidades]

        public DbSet<GeneroPet> GenerosPet { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetUsuario> PetUsuarios { get; set; }
        public DbSet<SituacaoSolicitacaoPet> SituacoesSolicitacaoPet { get; set; }
        public DbSet<SolicitacaoPet> SolicitacoesPet { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetOmetroContext).Assembly);
        }
    }
}
