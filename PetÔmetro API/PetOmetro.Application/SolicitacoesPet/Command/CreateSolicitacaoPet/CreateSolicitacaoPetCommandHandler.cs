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
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.SolicitacoesPet.Command.CreateSolicitacaoPet
{
    public class CreateSolicitacaoPetCommandHandler : IRequestHandler<CreateSolicitacaoPetCommand, SolicitacaoPetViewModel>
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthBaseApplication _authBaseApplication;

        public CreateSolicitacaoPetCommandHandler(PetOmetroContext context, IMapper mapper, IAuthBaseApplication authBaseApplication)
        {
            _context = context;
            _mapper = mapper;
            _authBaseApplication = authBaseApplication;
        }

        public async Task<SolicitacaoPetViewModel> Handle(CreateSolicitacaoPetCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _authBaseApplication.GetUsuarioLogado();

            var idUsuario = usuario.Id;

            if (idUsuario == request.IdUsuarioSolicitado)
                throw new BusinessException("Você não pode enviar uma solicitação a si mesmo.");

            var usuarioSolicitado = await _context.Usuarios.FirstOrDefaultAsync(e => e.Id == request.IdUsuarioSolicitado);

            if (usuarioSolicitado == null)
                throw new NotFoundException("Usuário", request.IdUsuarioSolicitado);

            var pet = await _context.Pets.FirstOrDefaultAsync(e => e.Id == request.IdPet);

            if (pet == null)
                throw new NotFoundException(nameof(Pet), request.IdPet);

            var possuiSolicitacao = await _context.SolicitacoesPet.AnyAsync(e => e.IdPet == request.IdPet
            && (e.IdUsuarioSolicitado == request.IdUsuarioSolicitado || e.IdUsuarioSolicitante == request.IdUsuarioSolicitado)
            && e.IdSituacaoSolicitacao == SituacaoSolicitacaoPetSeed.Pendente.Id);

            if (possuiSolicitacao)
                throw new BusinessException(string.Format("O usuário {0} já possui solicitação pendente para esse pet.", usuarioSolicitado.Nome));

            var dono = pet.IdUsuario == idUsuario;

            if (dono)
            {
                var petsAssociados = await _context.PetUsuarios.AnyAsync(e => e.IdPet == request.IdPet && e.IdUsuario == request.IdUsuarioSolicitado);
                if (petsAssociados)
                    throw new BusinessException(string.Format("O usuário {0} já está associado ao pet.", usuarioSolicitado.Nome));
            }
            else
            {
                var petsAssociados = await _context.PetUsuarios.AnyAsync(e => e.IdPet == request.IdPet && e.IdUsuario == idUsuario);
                if (petsAssociados)
                    throw new BusinessException("Você já está associado ao pet.");
            }

            var entity = _mapper.Map<SolicitacaoPet>(request);
            entity.IdUsuarioSolicitante = idUsuario;
            entity.IdSituacaoSolicitacao = SituacaoSolicitacaoPetSeed.Pendente.Id;
            entity.DataSolicitacao = DateTime.Now;

            try
            {
                _context.SolicitacoesPet.Add(entity);
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
