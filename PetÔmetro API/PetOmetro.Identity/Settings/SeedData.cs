using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetOmetro.Identity.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PetOmetro.Identity.Settings
{
    public class SeedData
    {
        private const string _testRoleName = "test";
        private readonly string _testEmail = "teste@teste.local";
        private readonly string _testePassword = "Teste!1234";

        private readonly string[] _defaultRoles = new string[] { _testRoleName };

        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public static async Task Run(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var instance = serviceScope.ServiceProvider.GetService<SeedData>();
                await instance.Initialize();
            }
        }

        public SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Initialize()
        {
            await EnsureRoles();
            await EnsureDefaultUser();
        }

        protected async Task EnsureRoles()
        {
            foreach (var role in _defaultRoles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>(role));
                }
            }
        }

        protected async Task EnsureDefaultUser()
        {
            var adminUsers = await _userManager.GetUsersInRoleAsync(_testRoleName);

            if (!adminUsers.Any())
            {
                var adminUser = new ApplicationUser()
                {
                    Email = _testEmail,
                    UserName = _testEmail,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(adminUser, _testePassword);
                await _userManager.AddToRoleAsync(adminUser, _testRoleName);
            }
        }

    }
}
