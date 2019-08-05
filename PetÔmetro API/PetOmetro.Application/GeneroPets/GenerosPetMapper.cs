using AutoMapper;
using PetOmetro.Application.GenerosPet.Models;
using PetOmetro.Application.Settings.AutoMapper;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Application.GenerosPet
{
    public class GenerosPetMapper : BaseMapper
    {
        public GenerosPetMapper(Profile profile)
            : base(profile)
        {
        }

        protected override void Map(Profile profile)
        {
            profile.CreateMap<GeneroPet, GeneroPetViewModel>();
        }
    }
}
