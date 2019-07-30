using FluentValidation;

namespace PetOmetro.Application.Usuarios.Commands.Auth
{
    public class AuthCommandValidator : AbstractValidator<AuthCommand>
    {
        public AuthCommandValidator()
        {
            RuleFor(e => e.Login)
                .NotEmpty();

            RuleFor(e => e.Senha)
                .NotEmpty();
        }
    }
}
