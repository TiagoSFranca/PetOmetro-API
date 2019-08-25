using AutoMapper;
using PetOmetro.Application.Settings.AutoMapper;
using PetOmetro.Application.Usuarios.Models;
using PetOmetro.Identity.Models;

namespace PetOmetro.Application.Usuarios
{
    public class UsuariosMapper : BaseMapper
    {
        public UsuariosMapper(Profile profile)
            : base(profile)
        {
        }

        protected override void Map(Profile profile)
        {
            profile.CreateMap<ApplicationUser, UsuarioItemViewModel>().ReverseMap();
            profile.CreateMap<ApplicationUser, UsuarioViewModel>().ReverseMap();
            profile.CreateMap<ApplicationUser, AuthUsuario>();
        }
    }
}
