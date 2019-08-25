using Microsoft.AspNetCore.Identity;

namespace PetOmetro.Identity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Nome { get; set; }
    }
}
