using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetOmetro.Application.GeneroPets.Models;
using PetOmetro.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.GeneroPets.Queries.GetGeneroPets
{
    public class GetGeneroPetsQueryHandler : IRequestHandler<GetGeneroPetsQuery, List<GeneroPetViewModel>>
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;

        public GetGeneroPetsQueryHandler(PetOmetroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GeneroPetViewModel>> Handle(GetGeneroPetsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.GeneroPets.AsQueryable();

            if ((request.Ids ?? new List<int>()).Count > 0)
                query = query.Where(e => request.Ids.Contains(e.Id));
            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(e => e.Nome.ToLower().Contains(request.Nome.ToLower()));

            var data = await query.ToListAsync();

            return _mapper.Map<List<GeneroPetViewModel>>(data);
        }
    }
}
