using FluentValidation;

namespace PetOmetro.Application.SolicitacoesPet.Command.CancelSolicitacaoPet
{
    public class CancelSolicitacaoPetCommandValidator : AbstractValidator<CancelSolicitacaoPetCommand>
    {
        public CancelSolicitacaoPetCommandValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0);
        }
    }
}
