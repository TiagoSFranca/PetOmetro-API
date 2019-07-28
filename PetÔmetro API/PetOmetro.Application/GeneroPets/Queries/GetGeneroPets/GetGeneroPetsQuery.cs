using MediatR;
using PetOmetro.Application.GeneroPets.Models;
using System.Collections.Generic;

namespace PetOmetro.Application.GeneroPets.Queries.GetGeneroPets
{
    public class GetGeneroPetsQuery : IRequest<List<GeneroPetViewModel>>
    {
        public List<int> Ids { get; set; }
        public string Nome { get; set; }
    }
}
