using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Interfaces.Services;
using PetOmetro.Application.Pets.Models;
using PetOmetro.Domain.Entities;
using PetOmetro.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, PetViewModel>
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthBaseApplication _authBaseApplication;
        private readonly IFileService _fileService;

        public UpdatePetCommandHandler(PetOmetroContext context, IMapper mapper, IAuthBaseApplication authBaseApplication, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _authBaseApplication = authBaseApplication;
            _fileService = fileService;
        }

        public async Task<PetViewModel> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _authBaseApplication.GetUsuarioLogado();
            var idUsuario = usuario.Id;

            var entity = await _context.Pets.FirstOrDefaultAsync(e => e.Id == request.Id && e.IdUsuario == idUsuario);

            if (entity == null)
                throw new NotFoundException(nameof(Pet), request.Id);

            var genero = await _context.GenerosPet.FindAsync(request.IdGeneroPet);
            if (genero == null)
                throw new NotFoundException("Gênero Pet", request.IdGeneroPet);

            string path = string.Empty;

            try
            {
                _mapper.Map(request, entity);

                if (request.Imagem?.Length > 0)
                {
                    path = _fileService.UploadFile(request.Imagem, null);
                    entity.UrlImagem = path;
                }
                else if (string.IsNullOrEmpty(request.UrlImagem))
                {
                    entity.UrlImagem = path;
                }

                _context.Pets.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _fileService.DeleteFile(path);
                throw new PersistenceException(ex);
            }

            return _mapper.Map<PetViewModel>(entity);
        }
    }
}
