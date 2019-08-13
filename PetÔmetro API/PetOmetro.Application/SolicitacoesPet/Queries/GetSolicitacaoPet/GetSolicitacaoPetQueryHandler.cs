using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.SolicitacoesPet.Models;
using PetOmetro.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.SolicitacoesPet.Queries.GetSolicitacaoPet
{
    public class GetSolicitacaoPetQueryHandler : IRequestHandler<GetSolicitacaoPetQuery, SolicitacaoPetViewModel>
    {
        private readonly PetOmetroContext _context;
        private readonly IAuthBaseApplication _authBaseApplication;
        private readonly IMapper _mapper;

        public GetSolicitacaoPetQueryHandler(PetOmetroContext context, IAuthBaseApplication authBaseApplication, IMapper mapper)
        {
            _context = context;
            _authBaseApplication = authBaseApplication;
            _mapper = mapper;
        }

        public async Task<SolicitacaoPetViewModel> Handle(GetSolicitacaoPetQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _authBaseApplication.GetUsuarioLogado();
            var idUsuario = usuario.Id;

            var query = _context.SolicitacoesPet.AsQueryable();

            query = query.Where(e => e.IdUsuarioSolicitado == idUsuario || e.IdUsuarioSolicitante == idUsuario);

            var entity = await query.FirstOrDefaultAsync(e => e.IdUsuarioSolicitado == request.Id || e.IdUsuarioSolicitante == request.Id);

            if (entity == null)
                throw new NotFoundException("Solicitação Pet", request.Id);

            return _mapper.Map<SolicitacaoPetViewModel>(entity);
        }
    }
}
