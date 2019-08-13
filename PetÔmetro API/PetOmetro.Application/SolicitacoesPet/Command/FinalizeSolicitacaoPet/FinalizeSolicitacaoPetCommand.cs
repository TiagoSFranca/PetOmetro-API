using MediatR;
using PetOmetro.Application.SolicitacoesPet.Models;

namespace PetOmetro.Application.SolicitacoesPet.Command.FinalizeSolicitacaoPet
{
    public class FinalizeSolicitacaoPet
    {
        public int Id { get; set; }
        public bool Recusado { get; set; }
    }

    public class FinalizeSolicitacaoPetCommand : IRequest<SolicitacaoPetViewModel>
    {
        public int Id { get; set; }
        public bool Recusado { get; set; }
    }
}
