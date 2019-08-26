using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetOmetro.API.Filters;
using PetOmetro.API.Helpers;
using PetOmetro.Application.GenerosPet.Queries.GetGeneroPets;
using PetOmetro.Application.Settings.Models;
using PetOmetro.Identity.IdentityServer;
using PetOmetro.Identity.Models;
using PetOmetro.Identity.Settings;
using PetOmetro.Persistence;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace PetOmetro.API
{
    public class Startup
    {
        private const string _appSettingsSectionName = "AppSettings";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _appSettingsSection = Configuration
                .GetSection(_appSettingsSectionName);

            _appSettings = _appSettingsSection.Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }

        private readonly IConfigurationSection _appSettingsSection;

        private readonly AppSettings _appSettings;

        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjectionHelper.Configure(services);

            services
                .AddMediatR(typeof(GetGenerosPetQuery).GetTypeInfo().Assembly);

            services
                .AddCors();

            services
                .AddMvc(options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                    //var policy = new AuthorizationPolicyBuilder()
                    //       .RequireAuthenticatedUser()
                    //       .RequireScope(Config._apiName).Build();
                    //options.Filters.Add(new AuthorizeFilter(policy));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetGenerosPetQuery>());

            services
                .AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
                {
                    options.Password = new PasswordOptions()
                    {
                        RequireDigit = false,
                        RequiredLength = 8,
                        RequiredUniqueChars = 0,
                        RequireLowercase = false,
                        RequireNonAlphanumeric = false,
                        RequireUppercase = false
                    };
                })
                .AddEntityFrameworkStores<PetOmetroContext>()
                .AddDefaultTokenProviders()
                .AddPasswordValidator<ApplicationPasswordValidator>();

            services.AddDbContext<PetOmetroContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("PetOmetroConnection")));


            services
                .Configure<AppSettings>(_appSettingsSection);

            services
                .Configure<ApiBehaviorOptions>(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            services.AddAuthorization();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = _appSettings.Authority;

                    options.ApiName = Config._apiName;
                    options.ApiSecret = Config._apiSecret;

                    options.RequireHttpsMetadata = false;
                });

            services
                .AddSwaggerGen(c =>
                {
                    c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                    c.SwaggerDoc(_appSettings.Version, new Info
                    {
                        Version = _appSettings.Version,
                        Title = _appSettings.Name,
                        Description = _appSettings.Description,
                        TermsOfService = "None",
                    });
                    c.OperationFilter<FileUploadOperation>();
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", _appSettings.Name + " " + _appSettings.Version);
            });

            // global cors policy
            app
                .UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app
                .UseAuthentication();

            app
                .UseHttpsRedirection();
            app
                .UseMvc();

            SeedData.Run(app.ApplicationServices).Wait();
        }

    }
}
