using Microsoft.EntityFrameworkCore;
using PetOmetro.Persistence.Settings;

namespace PetOmetro.Persistence
{
    public class PetOmetroContextFactory : DesignTimeDbContextFactoryBase<PetOmetroContext>
    {
        protected override PetOmetroContext CreateNewInstance(DbContextOptions<PetOmetroContext> options)
        {
            return new PetOmetroContext(options);
        }
    }
}
