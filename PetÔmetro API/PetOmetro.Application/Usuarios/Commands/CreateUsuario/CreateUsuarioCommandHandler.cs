using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Usuarios.Models;
using PetOmetro.Common.Helpers;
using PetOmetro.Domain.Entities;
using PetOmetro.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, AuthUsuario>
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;

        public CreateUsuarioCommandHandler(PetOmetroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthUsuario> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioMapped = _mapper.Map<UsuarioViewModel>(request);

            if (await _context.Usuarios.AnyAsync(e => e.Login.ToLower().Equals(usuarioMapped.Login.ToLower())))
                throw new BusinessException("Login já cadastrado");

            if (await _context.Usuarios.AnyAsync(e => e.Email.ToLower().Equals(usuarioMapped.Email.ToLower())))
                throw new BusinessException("E-mail já cadastrado");

            var entity = _mapper.Map<Usuario>(usuarioMapped);
            entity.Senha = CryptoHelper.Encrypt(request.Senha);

            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new PersistenceException(e);
            }

            var retorno = _mapper.Map<AuthUsuario>(entity);

            try
            {
                var token = "";
                retorno.Token = token;
            }
            catch (Exception)
            {
            }

            return retorno;
        }
    }
}
