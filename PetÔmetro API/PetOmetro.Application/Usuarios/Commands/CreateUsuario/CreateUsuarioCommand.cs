using MediatR;
using PetOmetro.Application.Usuarios.Models;

namespace PetOmetro.Application.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class CreateUsuarioCommand : IRequest<AuthUsuario>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
