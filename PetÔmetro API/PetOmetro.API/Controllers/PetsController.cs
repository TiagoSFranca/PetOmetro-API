using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Pets.Commands.CreatePet;
using PetOmetro.Application.Pets.Models;
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
            var query = Mapper.Map<CreatePetCommand>(model);

            return Ok(await Mediator.Send(query));
        }
    }
}
