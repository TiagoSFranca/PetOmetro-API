using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Paginacoes.Models;
using PetOmetro.Application.Pets.Commands.CreatePet;
using PetOmetro.Application.Pets.Models;
using PetOmetro.Application.Pets.Queries.GetPets;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PetOmetro.API.Controllers
{
    public class PetsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PetViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequest))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<PetViewModel>> Create(CreatePet model)
        {
            var command = Mapper.Map<CreatePetCommand>(model);

            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ConsultaPaginadaViewModel<PetViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<ConsultaPaginadaViewModel<PetViewModel>>> GetAll([FromQuery]List<int> ids, [FromQuery]string nome,
            [FromQuery]string especie, [FromQuery]string raca, [FromQuery]List<int> idGeneros, [FromQuery]int? pagina, [FromQuery]int? itensPorPagina)
        {
            var query = new GetPetsQuery()
            {
                Ids = ids,
                Nome = nome,
                Especie = especie,
                Raca = raca,
                IdGeneros = idGeneros,
                Paginacao = new PaginacaoViewModel(pagina, itensPorPagina)
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
