using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetOmetro.Identity.Models;
using PetOmetro.Identity.Settings;

namespace PetOmetro.IdentityServer.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<UserManager<ApplicationUser>, ApplicationUserManager>();
            services.AddTransient<SignInManager<ApplicationUser>, ApplicationSignInManager>();
            services.AddTransient<SeedData>();

        }
    }
}
