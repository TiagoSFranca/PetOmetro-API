using PetOmetro.Domain.Seeds;
using System.Linq;

namespace PetOmetro.Persistence
{
    public class PetOmetroInitializer
    {
        public static void Initialize(PetOmetroContext context)
        {
            var instance = new PetOmetroInitializer();
            instance.Seed(context);
        }

        private void Seed(PetOmetroContext context)
        {
            SeedGeneroPet(context);
        }

        private void SeedGeneroPet(PetOmetroContext context)
        {
            if (context.GeneroPets.Any())
                return;
            context.GeneroPets.AddRange(GeneroPetSeed.Seeds);
            context.SaveChanges();
        }
    }
}
