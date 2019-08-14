using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.SolicitacoesPet.Models;
using PetOmetro.Domain.Entities;
using PetOmetro.Domain.Seeds;
using PetOmetro.Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.SolicitacoesPet.Command.FinalizeSolicitacaoPet
{
    public class FinalizeSolicitacaoPetCommandHandler : IRequestHandler<FinalizeSolicitacaoPetCommand, SolicitacaoPetViewModel>
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthBaseApplication _authBaseApplication;

        public FinalizeSolicitacaoPetCommandHandler(PetOmetroContext context, IMapper mapper, IAuthBaseApplication authBaseApplication)
        {
            _context = context;
            _mapper = mapper;
            _authBaseApplication = authBaseApplication;
        }

        public async Task<SolicitacaoPetViewModel> Handle(FinalizeSolicitacaoPetCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _authBaseApplication.GetUsuarioLogado();
            var idUsuario = usuario.Id;

            var query = _context.SolicitacoesPet.AsQueryable();

            var entity = await query.FirstOrDefaultAsync(e => e.Id == request.Id && e.IdUsuarioSolicitado == idUsuario);

            if (entity == null)
                throw new NotFoundException("Solicitação Pet", request.Id);

            if (entity.IdSituacaoSolicitacao != SituacaoSolicitacaoPetSeed.Pendente.Id)
                throw new BusinessException("A solicitação não está mais pendente.");

            entity.IdSituacaoSolicitacao = request.Recusado ? SituacaoSolicitacaoPetSeed.Recusada.Id : SituacaoSolicitacaoPetSeed.Aceita.Id;
            entity.DataFinalizacao = DateTime.Now;
            entity.Visualizado = true;

            try
            {
                _context.SolicitacoesPet.Update(entity);
                if (!request.Recusado)
                {
                    var pet = await _context.Pets.FindAsync(entity.IdPet);

                    PetUsuario petUsuario = new PetUsuario()
                    {
                        IdPet = entity.IdPet,
                        IdUsuario = pet.IdUsuario == entity.IdUsuarioSolicitado ? entity.IdUsuarioSolicitante : entity.IdUsuarioSolicitado
                    };

                    _context.PetUsuarios.Add(petUsuario);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex);
            }

            return _mapper.Map<SolicitacaoPetViewModel>(entity);
        }
    }
}
