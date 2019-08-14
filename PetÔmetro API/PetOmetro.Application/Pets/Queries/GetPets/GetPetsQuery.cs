using MediatR;
using PetOmetro.Application.Paginacoes.Models;
using PetOmetro.Application.Pets.Models;
using System.Collections.Generic;

namespace PetOmetro.Application.Pets.Queries.GetPets
{
    public class GetPetsQuery : IRequest<ConsultaPaginadaViewModel<PetViewModel>>
    {
        public List<int> Ids { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public List<int> IdGeneros { get; set; }
        public bool MeusPets { get; set; }
        public bool? Dono { get; set; }
        public PaginacaoViewModel Paginacao { get; set; }
    }
}
