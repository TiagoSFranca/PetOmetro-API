using System.Collections.Generic;

namespace PetOmetro.Domain.Domain
{
    public class GeneroPet
    {
        public GeneroPet()
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
