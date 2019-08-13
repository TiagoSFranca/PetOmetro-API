using MediatR;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Paginacoes.Models;
using PetOmetro.Application.SolicitacoesPet.Models;
using PetOmetro.Domain.Entities;
using PetOmetro.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.SolicitacoesPet.Queries.GetSolicitacoesPet
{
    public class GetSolicitacoesPetQueryHandler : IRequestHandler<GetSolicitacoesPetQuery, ConsultaPaginadaViewModel<SolicitacaoPetViewModel>>
    {
        private readonly PetOmetroContext _context;
        private readonly IPaginacaoBaseApplication<SolicitacaoPet, SolicitacaoPetViewModel> _paginacaoBaseApplication;
        private readonly IAuthBaseApplication _authBaseApplication;

        public GetSolicitacoesPetQueryHandler(PetOmetroContext context, IPaginacaoBaseApplication<SolicitacaoPet, SolicitacaoPetViewModel> paginacaoBaseApplication,
            IAuthBaseApplication authBaseApplication)
        {
            _context = context;
            _paginacaoBaseApplication = paginacaoBaseApplication;
            _authBaseApplication = authBaseApplication;
        }

        public async Task<ConsultaPaginadaViewModel<SolicitacaoPetViewModel>> Handle(GetSolicitacoesPetQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _authBaseApplication.GetUsuarioLogado();
            var idUsuario = usuario.Id;

            var query = _context.SolicitacoesPet.AsQueryable();

            query = query.Where(e => e.IdUsuarioSolicitado == idUsuario || e.IdUsuarioSolicitante == idUsuario);

            if ((request.Ids ?? new List<int>()).Count > 0)
                query = query.Where(e => request.Ids.Contains(e.Id));

            if ((request.IdSituacoesSolicitacao ?? new List<int>()).Count > 0)
                query = query.Where(e => request.IdSituacoesSolicitacao.Contains(e.IdSituacaoSolicitacao));

            if ((request.IdSolicitados ?? new List<int>()).Count > 0)
                query = query.Where(e => request.IdSolicitados.Contains(e.IdUsuarioSolicitado));

            if ((request.IdSolicitantes ?? new List<int>()).Count > 0)
                query = query.Where(e => request.IdSolicitantes.Contains(e.IdUsuarioSolicitante));

            if ((request.IdPets ?? new List<int>()).Count > 0)
                query = query.Where(e => request.IdPets.Contains(e.IdPet));

            if (request.Visualizado != null)
                query = query.Where(e => e.Visualizado == request.Visualizado);

            var paginacao = request.Paginacao ?? new PaginacaoViewModel();

            var retorno = await _paginacaoBaseApplication.Paginar(query, paginacao);

            return retorno;
        }
    }
}
