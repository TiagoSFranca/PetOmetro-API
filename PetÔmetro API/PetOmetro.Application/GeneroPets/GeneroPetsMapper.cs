using AutoMapper;
using PetOmetro.Application.Settings.AutoMapper;
using System;

namespace PetOmetro.Application.GeneroPets
{
    public class GeneroPetsMapper : BaseMapper
    {
        public GeneroPetsMapper(Profile profile)
        {
            Map(profile);
        }

        protected override void Map(Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}
