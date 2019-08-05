using MediatR;
using PetOmetro.Application.GenerosPet.Models;
using System.Collections.Generic;

namespace PetOmetro.Application.GenerosPet.Queries.GetGeneroPets
{
    public class GetGenerosPetQuery : IRequest<List<GeneroPetViewModel>>
    {
        public List<int> Ids { get; set; }
        public string Nome { get; set; }
    }
}
