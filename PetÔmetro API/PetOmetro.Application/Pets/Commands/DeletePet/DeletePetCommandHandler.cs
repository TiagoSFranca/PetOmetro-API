using MediatR;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Interfaces.Services;
using PetOmetro.Domain.Entities;
using PetOmetro.Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.Pets.Commands.DeletePet
{
    public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand>
    {
        private readonly PetOmetroContext _context;
        private readonly IAuthBaseApplication _authBaseApplication;
        private readonly IFileService _fileService;

        public DeletePetCommandHandler(PetOmetroContext context, IAuthBaseApplication authBaseApplication, IFileService fileService)
        {
            _context = context;
            _authBaseApplication = authBaseApplication;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(DeletePetCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _authBaseApplication.GetUsuarioLogado();
            var idUsuario = usuario.Id;

            var query = _context.Pets.AsQueryable();

            var entity = await query.FirstOrDefaultAsync(e => e.Id == request.Id && e.IdUsuario == idUsuario);

            if (entity == null)
                throw new NotFoundException(nameof(Pet), request.Id);

            var path = entity.UrlImagem;

            try
            {
                _context.Pets.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex);
            }

            _fileService.DeleteFile(path);

            return Unit.Value;
        }
    }
}
