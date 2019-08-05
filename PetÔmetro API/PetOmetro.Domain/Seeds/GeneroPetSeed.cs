using PetOmetro.Domain.Entities;
using System.Collections.Generic;

namespace PetOmetro.Domain.Seeds
{
    public class GeneroPetSeed
    {
        public static GeneroPet Macho => new GeneroPet() { Id = 1, Nome = "Macho" };
        public static GeneroPet Femea => new GeneroPet() { Id = 2, Nome = "Fêmea" };
        public static GeneroPet Indeterminado => new GeneroPet() { Id = 3, Nome = "Indeterminado" };

        public static List<GeneroPet> Seeds => new List<GeneroPet>()
        {
            Macho,
            Femea,
            Indeterminado
        };

    }
}
