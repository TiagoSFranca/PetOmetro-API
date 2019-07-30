using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.Services;
using PetOmetro.Application.Usuarios.Models;
using PetOmetro.Common.Helpers;
using PetOmetro.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.Usuarios.Commands.Auth
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthUsuario>
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public AuthCommandHandler(PetOmetroContext context, IMapper mapper, IJwtService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<AuthUsuario> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(e => e.Email.ToLower().Equals(request.Login.ToLower()) || e.Login.ToLower().Equals(request.Login.ToLower()));

            if (usuario == null)
                throw new BusinessException("Usuário não encontrado.");

            var senha = CryptoHelper.Encrypt(request.Senha);

            if (!usuario.Senha.Equals(senha))
                throw new BusinessException("Login ou Senha inválidos.");

            var retorno = _mapper.Map<AuthUsuario>(usuario);

            try
            {
                var token = _jwtService.GetToken(usuario);
                retorno.Token = token;
            }
            catch (Exception)
            {
                throw new BusinessException("Ocorreu um erro ao gerar o token.");
            }

            return retorno;
        }
    }
}
