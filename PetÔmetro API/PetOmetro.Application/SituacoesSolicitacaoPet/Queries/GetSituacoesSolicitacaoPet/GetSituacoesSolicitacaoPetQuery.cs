using MediatR;
using PetOmetro.Domain.Entities;
using System.Collections.Generic;

namespace PetOmetro.Application.SituacoesSolicitacaoPet.Queries.GetSituacoesSolicitacaoPet
{
    public class GetSituacoesSolicitacaoPetQuery : IRequest<List<SituacaoSolicitacaoPet>>
    {
        public List<int> Ids { get; set; }
        public string Nome { get; set; }
    }
}
