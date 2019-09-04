using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Paginacoes.Models;
using PetOmetro.Application.Pets.Commands.CreatePet;
using PetOmetro.Application.Pets.Commands.DeletePet;
using PetOmetro.Application.Pets.Commands.UpdatePet;
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
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PetViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequest))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ResponseUnauthorized))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<PetViewModel>> Create([FromForm]CreatePet model)
        {
            var command = Mapper.Map<CreatePetCommand>(model);

            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ConsultaPaginadaViewModel<PetViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<ConsultaPaginadaViewModel<PetViewModel>>> GetAll([FromQuery]List<int> ids, [FromQuery]string nome,
            [FromQuery]string especie, [FromQuery]string raca, [FromQuery]List<int> idGeneros, [FromQuery]bool? dono, [FromQuery]int? pagina, [FromQuery]int? itensPorPagina, [FromQuery]bool meusPets = false)
        {
            var query = new GetPetsQuery()
            {
                Ids = ids,
                Nome = nome,
                Especie = especie,
                Raca = raca,
                IdGeneros = idGeneros,
                MeusPets = meusPets,
                Dono = dono,
                Paginacao = new PaginacaoViewModel(pagina, itensPorPagina)
            };

            return Ok(await Mediator.Send(query));
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ResponseUnauthorized))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePetCommand() { Id = id });

            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PetViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequest))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ResponseUnauthorized))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<PetViewModel>> Update(int id, [FromForm]UpdatePet model)
        {
            var command = Mapper.Map<UpdatePetCommand>(model);

            return Ok(await Mediator.Send(command));
        }
    }
}
