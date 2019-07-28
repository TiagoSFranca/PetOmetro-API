using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetOmetro.API.Filters;
using PetOmetro.Application.GeneroPets.Queries.GetGeneroPets;
using PetOmetro.Application.Settings;
using PetOmetro.Application.Settings.AutoMapper;
using PetOmetro.Application.Settings.Models;
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

        private readonly IConfigurationSection _appSettingsSection;

        private readonly AppSettings _appSettings;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            #region Dependency Injections

            //services.TryAddTransient<ISpotifyService, SpotifyService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            #endregion

            services.AddMediatR(typeof(GetGeneroPetsQuery).GetTypeInfo().Assembly);

            services.AddCors();

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetGeneroPetsQuery>());

            services.AddDbContext<PetOmetroContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("PetOmetroConnection")));


            services.Configure<AppSettings>(_appSettingsSection);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(_appSettings.Version, new Info
                {
                    Version = _appSettings.Version,
                    Title = _appSettings.Name,
                    Description = _appSettings.Description,
                    TermsOfService = "None",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", _appSettings.Name + " " + _appSettings.Version);
            });

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
