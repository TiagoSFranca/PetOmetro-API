using MediatR;
using PetOmetro.Application.Paginacoes.Models;
using PetOmetro.Application.SolicitacoesPet.Models;
using System.Collections.Generic;

namespace PetOmetro.Application.SolicitacoesPet.Queries.GetSolicitacoesPet
{
    public class GetSolicitacoesPetQuery : IRequest<ConsultaPaginadaViewModel<SolicitacaoPetViewModel>>
    {
        public List<int> Ids { get; set; }
        public List<int> IdSolicitantes { get; set; }
        public List<int> IdSolicitados { get; set; }
        public List<int> IdPets { get; set; }
        public List<int> IdSituacoesSolicitacao { get; set; }
        public bool? Visualizado { get; set; }

        public PaginacaoViewModel Paginacao { get; set; }
    }
}
