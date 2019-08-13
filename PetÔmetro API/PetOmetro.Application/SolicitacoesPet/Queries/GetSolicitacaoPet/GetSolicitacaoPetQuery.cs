using MediatR;
using PetOmetro.Application.SolicitacoesPet.Models;

namespace PetOmetro.Application.SolicitacoesPet.Queries.GetSolicitacaoPet
{
    public class GetSolicitacaoPetQuery : IRequest<SolicitacaoPetViewModel>
    {
        public int Id { get; set; }
    }
}
