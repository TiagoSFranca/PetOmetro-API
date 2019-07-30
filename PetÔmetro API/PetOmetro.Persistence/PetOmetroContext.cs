using Microsoft.EntityFrameworkCore;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Persistence
{
    public class PetOmetroContext : DbContext
    {
        public PetOmetroContext(DbContextOptions<PetOmetroContext> options)
            : base(options)
        {
        }

        #region [Entidades]

        public DbSet<GeneroPet> GeneroPets { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PetUsuario> PetUsuarios { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetOmetroContext).Assembly);
        }
    }
}
