using PetOmetro.Domain.Entities;

namespace PetOmetro.Application.Interfaces.Services
{
    public interface IJwtService
    {
        int? Id { get; }
        string Login { get; }
        string GetToken(Usuario usuario);
    }
}
