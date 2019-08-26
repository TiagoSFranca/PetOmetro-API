using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Usuarios.Commands.RegisterUsuario;
using System.Net;
using System.Threading.Tasks;

namespace PetOmetro.API.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost("Register")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequest))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ResponseUnauthorized))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<IActionResult> Create([FromBody]RegisterUsuario model)
        {
            var command = Mapper.Map<RegisterUsuarioCommand>(model);

            await Mediator.Send(command);

            return NoContent();
        }

    }
}
