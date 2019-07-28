using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace PetOmetro.Application.Settings.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(AutoMapperProfile));

            var types = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(BaseMapper))).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type, this);
            }
        }
    }
}
