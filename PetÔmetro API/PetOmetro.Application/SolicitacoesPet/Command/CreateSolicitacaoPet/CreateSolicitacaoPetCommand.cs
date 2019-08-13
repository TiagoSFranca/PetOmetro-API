using MediatR;
using PetOmetro.Application.SolicitacoesPet.Models;

namespace PetOmetro.Application.SolicitacoesPet.Command.CreateSolicitacaoPet
{
    public class CreateSolicitacaoPet
    {
        public int IdUsuarioSolicitado { get; set; }
        public int IdPet { get; set; }
    }

    public class CreateSolicitacaoPetCommand : IRequest<SolicitacaoPetViewModel>
    {
        public int IdUsuarioSolicitado { get; set; }
        public int IdPet { get; set; }
    }
}
