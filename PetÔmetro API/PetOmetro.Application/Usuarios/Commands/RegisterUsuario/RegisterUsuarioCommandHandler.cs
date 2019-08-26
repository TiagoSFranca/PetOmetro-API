using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PetOmetro.Application.Exceptions;
using PetOmetro.Identity.Exceptions;
using PetOmetro.Identity.Models;
using PetOmetro.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.Usuarios.Commands.RegisterUsuario
{
    public class RegisterUsuarioCommandHandler : IRequestHandler<RegisterUsuarioCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;

        public RegisterUsuarioCommandHandler(UserManager<ApplicationUser> userManager, PetOmetroContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioExistente = await _userManager.FindByEmailAsync(request.Email);

            if (usuarioExistente != null)
                throw new BusinessException("Já existe um usuário cadastrado para esse email");

            usuarioExistente = await _userManager.FindByNameAsync(request.UserName);

            if (usuarioExistente != null)
                throw new BusinessException("Já existe um usuário cadastrado para esse login.");

            var usuario = _mapper.Map<ApplicationUser>(request);
            try
            {
                var result = await _userManager.CreateAsync(usuario, request.Senha);
            }
            catch (PasswordException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }

            return Unit.Value;
        }
    }
}
