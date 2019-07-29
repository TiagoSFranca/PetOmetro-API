using PetOmetro.Application.Paginacoes.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PetOmetro.Application.Interfaces.BaseApplications
{
    public interface IPaginacaoBaseApplication<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        Task<ConsultaPaginadaViewModel<TViewModel>> Paginar(IQueryable<TEntity> query, PaginacaoViewModel paginacao);
    }
}
