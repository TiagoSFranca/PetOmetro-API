using MediatR;

namespace PetOmetro.Application.SolicitacoesPet.Command.CancelSolicitacaoPet
{
    public class CancelSolicitacaoPetCommand : IRequest
    {
        public int Id { get; set; }
    }
}
