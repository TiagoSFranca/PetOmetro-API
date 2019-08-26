using MediatR;

namespace PetOmetro.Application.Usuarios.Commands.RegisterUsuario
{
    public class RegisterUsuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterUsuarioCommand : IRequest
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
