using AutoMapper;
using MediatR;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Paginacoes.Models;
using PetOmetro.Application.Pets.Models;
using PetOmetro.Domain.Entities;
using PetOmetro.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.Pets.Queries.GetPets
{
    public class GetPetsQueryHandler : IRequestHandler<GetPetsQuery, ConsultaPaginadaViewModel<PetViewModel>>
    {
        private readonly PetOmetroContext _context;
        private readonly IMapper _mapper;
        private readonly IPaginacaoBaseApplication<Pet, PetViewModel> _paginacaoBaseApplication;

        public GetPetsQueryHandler(PetOmetroContext context, IMapper mapper, IPaginacaoBaseApplication<Pet, PetViewModel> paginacaoBaseApplication)
        {
            _context = context;
            _mapper = mapper;
            _paginacaoBaseApplication = paginacaoBaseApplication;
        }

        public async Task<ConsultaPaginadaViewModel<PetViewModel>> Handle(GetPetsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Pets.AsQueryable();

            if ((request.Ids ?? new List<int>()).Count > 0)
                query = query.Where(e => request.Ids.Contains(e.Id));

            if ((request.IdGeneros ?? new List<int>()).Count > 0)
                query = query.Where(e => request.IdGeneros.Contains(e.IdGeneroPet));

            if (!string.IsNullOrEmpty(request.Nome))
                query = query.Where(e => e.Nome.ToLower().Contains(request.Nome.ToLower()));

            if (!string.IsNullOrEmpty(request.Especie))
                query = query.Where(e => e.Especie.ToLower().Contains(request.Especie.ToLower()));

            if (!string.IsNullOrEmpty(request.Raca))
                query = query.Where(e => e.Raca.ToLower().Contains(request.Raca.ToLower()));

            var paginacao = request.Paginacao ?? new PaginacaoViewModel();

            var retorno = await _paginacaoBaseApplication.Paginar(query, paginacao);

            return retorno;
        }
    }
}
