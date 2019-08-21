using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetOmetro.Application.BaseApplications;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Interfaces.Services;
using PetOmetro.Application.Settings;
using PetOmetro.Application.Settings.AutoMapper;
using PetOmetro.Identity.Models;
using PetOmetro.Identity.Settings;
using PetOmetro.Infrastructure.Services;

namespace PetOmetro.API.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IAuthBaseApplication, AuthBaseApplication>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient(typeof(IPaginacaoBaseApplication<,>), typeof(PaginacaoBaseApplication<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient<UserManager<ApplicationUser>, ApplicationUserManager>();
            services.AddTransient<SignInManager<ApplicationUser>, ApplicationSignInManager>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile(provider.GetService<IHttpContextAccessor>()));
            }).CreateMapper());
        }
    }
}
