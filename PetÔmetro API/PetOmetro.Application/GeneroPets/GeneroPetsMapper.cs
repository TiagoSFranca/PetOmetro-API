using AutoMapper;
using PetOmetro.Application.GeneroPets.Models;
using PetOmetro.Application.Settings.AutoMapper;
using PetOmetro.Domain.Entities;

namespace PetOmetro.Application.GeneroPets
{
    public class GeneroPetsMapper : BaseMapper
    {
        public GeneroPetsMapper(Profile profile)
            : base(profile)
        {
        }

        protected override void Map(Profile profile)
        {
            profile.CreateMap<GeneroPet, GeneroPetViewModel>();
        }
    }
}
