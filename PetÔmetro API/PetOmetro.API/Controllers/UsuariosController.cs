using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Usuarios.Commands.Auth;
using PetOmetro.Application.Usuarios.Commands.CreateUsuario;
using PetOmetro.Application.Usuarios.Models;
using System.Net;
using System.Threading.Tasks;

namespace PetOmetro.API.Controllers
{
    public class UsuariosController : BaseController
    {
        [HttpPost("Cadastrar")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AuthUsuario))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequest))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<AuthUsuario>> Cadastrar(CreateUsuario model)
        {
            var command = Mapper.Map<CreateUsuarioCommand>(model);

            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Auth")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(AuthUsuario))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequest))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<AuthUsuario>> Autenticar(Auth model)
        {
            var command = Mapper.Map<AuthCommand>(model);

            return Ok(await Mediator.Send(command));
        }
    }
}
