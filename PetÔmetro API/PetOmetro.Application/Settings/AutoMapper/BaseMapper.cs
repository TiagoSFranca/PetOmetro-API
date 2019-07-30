using AutoMapper;

namespace PetOmetro.Application.Settings.AutoMapper
{
    public abstract class BaseMapper
    {
        public BaseMapper(Profile profile)
        {
            Map(profile);
        }

        protected abstract void Map(Profile profile);
    }
}
