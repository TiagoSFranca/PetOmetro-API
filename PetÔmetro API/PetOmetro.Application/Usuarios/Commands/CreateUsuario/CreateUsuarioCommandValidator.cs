using FluentValidation;

namespace PetOmetro.Application.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioCommandValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty()
                .MaximumLength(32)
                .MinimumLength(2);

            RuleFor(e => e.Login)
                .NotEmpty()
                .MaximumLength(64)
                .MinimumLength(4);

            RuleFor(e => e.Senha)
                .NotEmpty()
                .MaximumLength(64)
                .MinimumLength(8);

            RuleFor(e => e.Sobrenome)
                .MaximumLength(64);

            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(256)
                .MinimumLength(4);

        }
    }
}
