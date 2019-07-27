using Microsoft.EntityFrameworkCore;
using PetOmetro.Domain.Domain;

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

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetOmetroContext).Assembly);
        }
    }
}
