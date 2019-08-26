using FluentValidation;

namespace PetOmetro.Application.Usuarios.Commands.RegisterUsuario
{
    public class RegisterUsuarioCommandValidator : AbstractValidator<RegisterUsuarioCommand>
    {
        public RegisterUsuarioCommandValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(e => e.Senha)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(e => e.UserName)
                .NotEmpty();

            RuleFor(e => e.Nome)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
