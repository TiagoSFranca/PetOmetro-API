using AutoMapper;
using Microsoft.AspNetCore.Http;
using PetOmetro.Application.Pets;
using System;
using System.Linq;
using System.Reflection;

namespace PetOmetro.Application.Settings.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(IHttpContextAccessor acessor)
        {
            CreateMap<string, string>().ConvertUsing(str => str == null ? null : str.Trim());

            Assembly assembly = Assembly.GetAssembly(typeof(AutoMapperProfile));

            var types = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(BaseMapper))).ToList();

            foreach (var type in types)
            {
                Activator.CreateInstance(type, this);
            }

            SpecificMappers(acessor);
        }

        private void SpecificMappers(IHttpContextAccessor acessor)
        {
            new PetsMapper(this, acessor);
        }
    }
}
