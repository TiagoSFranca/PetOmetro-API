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
            SeedSituacaoSolicitacaoPet(context);
        }

        private void SeedSituacaoSolicitacaoPet(PetOmetroContext context)
        {
            if (context.SituacoesSolicitacaoPet.Any())
                return;
            context.SituacoesSolicitacaoPet.AddRange(SituacaoSolicitacaoPetSeed.Seeds);
            context.SaveChanges();
        }

        private void SeedGeneroPet(PetOmetroContext context)
        {
            if (context.GenerosPet.Any())
                return;
            context.GenerosPet.AddRange(GeneroPetSeed.Seeds);
            context.SaveChanges();
        }
    }
}
