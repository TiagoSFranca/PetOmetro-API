using PetOmetro.Identity.Models;

namespace PetOmetro.Domain.Entities
{
    public class PetUsuario
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPet { get; set; }

        public virtual ApplicationUser Usuario { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
