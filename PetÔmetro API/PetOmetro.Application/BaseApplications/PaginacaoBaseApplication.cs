using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Paginacoes.Models;
using PetOmetro.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetOmetro.Application.BaseApplications
{
    public class PaginacaoBaseApplication<TEntity, TViewModel> : IPaginacaoBaseApplication<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;

        public PaginacaoBaseApplication(PetOmetroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ConsultaPaginadaViewModel<TViewModel>> Paginar(IQueryable<TEntity> query, PaginacaoViewModel paginacao)
        {
            var totalItens = await _context.Set<TEntity>().CountAsync();

            var result = await query.Skip((paginacao.Pagina - 1) * paginacao.ItensPorPagina).Take(paginacao.ItensPorPagina).ToListAsync();

            var retorno = new ConsultaPaginadaViewModel<TViewModel>(paginacao.Pagina, paginacao.ItensPorPagina)
            {
                TotalItens = totalItens,
                Itens = _mapper.Map<List<TViewModel>>(result)
            };

            return retorno;
        }
    }
}
