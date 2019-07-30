using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Interfaces.Services;
using PetOmetro.Persistence;

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

        public int GetIdUsuario()
        {
            bool isAuth = IdUsuario != null && IdUsuario > 0;

            if (!isAuth)
                throw new AuthorizationException("Autenticação requerida.");

            return (int)IdUsuario;
        }
    }
}
