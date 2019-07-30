using MediatR;
using PetOmetro.Application.Usuarios.Models;

namespace PetOmetro.Application.Usuarios.Commands.Auth
{
    public class Auth
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class AuthCommand : IRequest<AuthUsuario>
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
