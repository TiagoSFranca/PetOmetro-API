﻿using MediatR;
using PetOmetro.Application.Interfaces.BaseApplications;
using PetOmetro.Application.Paginacoes.Models;
using PetOmetro.Application.Pets.Models;
using PetOmetro.Domain.Entities;
using PetOmetro.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetOmetro.Application.Pets.Queries.GetPets
{
    public class GetPetsQueryHandler : IRequestHandler<GetPetsQuery, ConsultaPaginadaViewModel<PetViewModel>>
    {
        private readonly PetOmetroContext _context;
        private readonly IPaginacaoBaseApplication<Pet, PetViewModel> _paginacaoBaseApplication;
        private readonly IAuthBaseApplication _authBaseApplication;

        public GetPetsQueryHandler(PetOmetroContext context, IPaginacaoBaseApplication<Pet, PetViewModel> paginacaoBaseApplication,
            IAuthBaseApplication authBaseApplication)
        {
            _context = context;
            _paginacaoBaseApplication = paginacaoBaseApplication;
            _authBaseApplication = authBaseApplication;
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

            if (request.MeusPets)
            {
                var usuario = await _authBaseApplication.GetUsuarioLogado();
                var idUsuario = usuario.Id;

                query = query.Where(e => e.IdUsuario == idUsuario || e.PetUsuarios.Any(p => p.IdUsuario == idUsuario));

                if (request.Dono != null)
                {
                    if (request.Dono == true)
                        query = query.Where(e => e.IdUsuario == idUsuario);
                    else
                        query = query.Where(e => e.PetUsuarios.Any(p => p.IdUsuario == idUsuario));

                }
            }

            var paginacao = request.Paginacao ?? new PaginacaoViewModel();

            var retorno = await _paginacaoBaseApplication.Paginar(query, paginacao);

            return retorno;
        }
    }
}
