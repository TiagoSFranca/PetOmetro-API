using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Interfaces.Services;
using PetOmetro.Domain.Entities;
using PetOmetro.Persistence;
using System.Threading.Tasks;

namespace PetOmetro.Application.BaseApplications
{
    public class AuthBaseApplication : IAuthBaseApplication
    {
        private readonly IJwtService _jwtService;
        private readonly PetOmetroContext _context;
        private readonly int? IdUsuario;

        public AuthBaseApplication(IJwtService jwtService, PetOmetroContext context)
        {
            _jwtService = jwtService;
            _context = context;
            IdUsuario = _jwtService.Id;
        }

        public async Task<Usuario> GetUsuarioLogado()
        {
            bool isAuth = IdUsuario != null && IdUsuario > 0;

            if (!isAuth)
                throw new AuthorizationException("Autenticação requerida.");

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(e => e.Id == (int)IdUsuario);

            if (usuario == null)
                throw new AuthorizationException("Usuário não encontrado.");

            return usuario;
        }
    }
}
