using AutoMapper;
using PetOmetro.Application.Settings.AutoMapper;
using PetOmetro.Application.Usuarios.Commands.CreateUsuario;
using PetOmetro.Application.Usuarios.Models;
using PetOmetro.Domain.Entities;

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
            profile.CreateMap<CreateUsuarioCommand, UsuarioViewModel>();
            profile.CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            profile.CreateMap<Usuario, AuthUsuario>();
            profile.CreateMap<CreateUsuario, CreateUsuarioCommand>();
        }
    }
}
