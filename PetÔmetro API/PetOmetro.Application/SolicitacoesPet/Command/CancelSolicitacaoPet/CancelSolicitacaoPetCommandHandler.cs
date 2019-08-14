using MediatR;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Domain.Seeds;
using PetOmetro.Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.SolicitacoesPet.Command.CancelSolicitacaoPet
{
    public class CancelSolicitacaoPetCommandHandler : IRequestHandler<CancelSolicitacaoPetCommand>
    {
        private readonly PetOmetroContext _context;
        private readonly IAuthBaseApplication _authBaseApplication;

        public CancelSolicitacaoPetCommandHandler(PetOmetroContext context, IAuthBaseApplication authBaseApplication)
        {
            _context = context;
            _authBaseApplication = authBaseApplication;
        }

        public async Task<Unit> Handle(CancelSolicitacaoPetCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _authBaseApplication.GetUsuarioLogado();
            var idUsuario = usuario.Id;

            var query = _context.SolicitacoesPet.AsQueryable();

            var entity = await query.FirstOrDefaultAsync(e => e.Id == request.Id && e.IdUsuarioSolicitante == idUsuario);

            if (entity == null)
                throw new NotFoundException("Solicitação Pet", request.Id);

            if (entity.IdSituacaoSolicitacao != SituacaoSolicitacaoPetSeed.Pendente.Id)
                throw new BusinessException("A solicitação não está mais pendente.");

            try
            {
                _context.SolicitacoesPet.Remove(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex);
            }

            return Unit.Value;
        }
    }
}
