using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Domain.Entities;
using PetOmetro.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.SituacoesSolicitacaoPet.Queries.GetSituacoesSolicitacaoPet
{
    public class GetSituacoesSolicitacaoPetQueryHandler : IRequestHandler<GetSituacoesSolicitacaoPetQuery, List<SituacaoSolicitacaoPet>>
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;

        public GetSituacoesSolicitacaoPetQueryHandler(PetOmetroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SituacaoSolicitacaoPet>> Handle(GetSituacoesSolicitacaoPetQuery request, CancellationToken cancellationToken)
        {
            var query = _context.SituacoesSolicitacaoPet.AsQueryable();

            if ((request.Ids ?? new List<int>()).Count > 0)
                query = query.Where(e => request.Ids.Contains(e.Id));

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(e => e.Nome.ToLower().Contains(request.Nome.ToLower()));

            var result = await query.ToListAsync();

            return _mapper.Map<List<SituacaoSolicitacaoPet>>(result);
        }
    }
}
