using FluentValidation;

namespace PetOmetro.Application.SolicitacoesPet.Command.FinalizeSolicitacaoPet
{
    public class FinalizeSolicitacaoPetCommandValidator : AbstractValidator<FinalizeSolicitacaoPetCommand>
    {
        public FinalizeSolicitacaoPetCommandValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0);
        }
    }
}
