using PetOmetro.Domain.Entities;

namespace PetOmetro.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GetToken(Usuario usuario);
    }
}
