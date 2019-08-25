using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Identity.Interfaces;
using PetOmetro.Identity.Models;
using PetOmetro.Persistence;
using System.Threading.Tasks;

namespace PetOmetro.Application.BaseApplications
{
    public class AuthBaseApplication : IAuthBaseApplication
    {
        private readonly PetOmetroContext _context;
        private readonly IIdentityServerAuthService _identityServerAuthService;
        private readonly int? IdUsuario;

        public AuthBaseApplication(PetOmetroContext context, IIdentityServerAuthService identityServerAuthService)
        {
            _context = context;
            _identityServerAuthService = identityServerAuthService;
            IdUsuario = _identityServerAuthService.Id;
        }

        public async Task<ApplicationUser> GetUsuarioLogado()
        {
            bool isAuth = IdUsuario != null && IdUsuario > 0;

            if (!isAuth)
                throw new AuthorizationException("Autenticação requerida.");

            var usuario = await _context.Users.FirstOrDefaultAsync(e => e.Id == (int)IdUsuario);

            if (usuario == null)
                throw new AuthorizationException("Usuário não encontrado.");

            return usuario;
        }

    }
}
