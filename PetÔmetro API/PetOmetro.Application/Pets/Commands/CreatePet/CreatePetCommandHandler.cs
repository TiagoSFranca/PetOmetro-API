using AutoMapper;
using MediatR;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
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

        public CreatePetCommandHandler(PetOmetroContext context, IMapper mapper, IAuthBaseApplication authBaseApplication)
        {
            _context = context;
            _mapper = mapper;
            _authBaseApplication = authBaseApplication;
        }

        public async Task<PetViewModel> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var idUsuario = _authBaseApplication.GetIdUsuario();

            var genero = await _context.GeneroPets.FindAsync(request.IdGeneroPet);
            if (genero == null)
                throw new NotFoundException("Gênero Pet", request.IdGeneroPet);

            var entity = _mapper.Map<Pet>(request);
            entity.IdUsuario = idUsuario;

            try
            {
                _context.Pets.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex);
            }

            return _mapper.Map<PetViewModel>(entity);
        }
    }
}
