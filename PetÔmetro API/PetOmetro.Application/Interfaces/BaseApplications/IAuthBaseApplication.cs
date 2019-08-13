using PetOmetro.Domain.Entities;
using System.Threading.Tasks;

namespace PetOmetro.Application.Interfaces.BaseApplications
{
    public interface IAuthBaseApplication
    {
        Task<Usuario> GetUsuarioLogado();
    }
}
