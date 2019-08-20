using AutoMapper;
using MediatR;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Interfaces.Services;
using PetOmetro.Application.Pets.Models;
using PetOmetro.Domain.Entities;
using PetOmetro.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, PetViewModel>
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;
        private readonly IAuthBaseApplication _authBaseApplication;
        private readonly IFileService _fileService;

        public CreatePetCommandHandler(PetOmetroContext context, IMapper mapper, IAuthBaseApplication authBaseApplication, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _authBaseApplication = authBaseApplication;
            _fileService = fileService;
        }

        public async Task<PetViewModel> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _authBaseApplication.GetUsuarioLogado();
            var idUsuario = usuario.Id;

            var genero = await _context.GenerosPet.FindAsync(request.IdGeneroPet);
            if (genero == null)
                throw new NotFoundException("Gênero Pet", request.IdGeneroPet);

            var entity = _mapper.Map<Pet>(request);
            entity.IdUsuario = idUsuario;

            string path = string.Empty;

            try
            {
                path = _fileService.UploadFile(request.Imagem, null);
                entity.UrlImagem = path;
                _context.Pets.Add(entity);
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
