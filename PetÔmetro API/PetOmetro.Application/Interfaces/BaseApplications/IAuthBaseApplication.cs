using PetOmetro.Identity.Models;
using System.Threading.Tasks;

namespace PetOmetro.Application.Interfaces.BaseApplications
{
    public interface IAuthBaseApplication
    {
        Task<ApplicationUser> GetUsuarioLogado();
    }
}
