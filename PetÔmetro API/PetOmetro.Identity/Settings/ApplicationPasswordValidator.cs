using Microsoft.AspNetCore.Identity;
using PetOmetro.Identity.Exceptions;
using PetOmetro.Identity.Models;
using System;
using System.Threading.Tasks;

namespace PetOmetro.Identity.Settings
{
    public class ApplicationPasswordValidator : IPasswordValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            if (string.Equals(user.UserName, password, StringComparison.OrdinalIgnoreCase))
            {
                throw new PasswordException("Você não pode usar a senha igual ao login");
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
