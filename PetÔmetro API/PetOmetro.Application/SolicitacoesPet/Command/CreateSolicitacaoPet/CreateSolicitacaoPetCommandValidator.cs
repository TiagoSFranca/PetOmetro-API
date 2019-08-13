using FluentValidation;

namespace PetOmetro.Application.SolicitacoesPet.Command.CreateSolicitacaoPet
{
    public class CreateSolicitacaoPetCommandValidator : AbstractValidator<CreateSolicitacaoPetCommand>
    {
        public CreateSolicitacaoPetCommandValidator()
        {
            RuleFor(e => e.IdPet)
                .GreaterThan(0);

            RuleFor(e => e.IdUsuarioSolicitado)
                .GreaterThan(0);
        }
    }
}
