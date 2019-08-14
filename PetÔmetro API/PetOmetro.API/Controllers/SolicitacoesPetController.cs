using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.Exceptions;
using PetOmetro.Application.Paginacoes.Models;
using PetOmetro.Application.SolicitacoesPet.Command.CancelSolicitacaoPet;
using PetOmetro.Application.SolicitacoesPet.Command.CreateSolicitacaoPet;
using PetOmetro.Application.SolicitacoesPet.Command.FinalizeSolicitacaoPet;
using PetOmetro.Application.SolicitacoesPet.Models;
using PetOmetro.Application.SolicitacoesPet.Queries.GetSolicitacaoPet;
using PetOmetro.Application.SolicitacoesPet.Queries.GetSolicitacoesPet;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PetOmetro.API.Controllers
{
    public class SolicitacoesPetController : BaseController
    {
        [HttpPost]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SolicitacaoPetViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequest))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ResponseUnauthorized))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<SolicitacaoPetViewModel>> Create(CreateSolicitacaoPet model)
        {
            var command = Mapper.Map<CreateSolicitacaoPetCommand>(model);

            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ConsultaPaginadaViewModel<SolicitacaoPetViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<ConsultaPaginadaViewModel<SolicitacaoPetViewModel>>> GetAll([FromQuery]List<int> ids,
            [FromQuery]List<int> idSolicitantes, [FromQuery]List<int> idSolicitados, [FromQuery]List<int> idPets, [FromQuery]List<int> idSituacoesSolicitacao,
            [FromQuery]bool? visualizado, [FromQuery]int? pagina, [FromQuery]int? itensPorPagina)
        {
            var query = new GetSolicitacoesPetQuery()
            {
                Ids = ids,
                IdPets = idPets,
                IdSituacoesSolicitacao = idSituacoesSolicitacao,
                IdSolicitados = idSolicitados,
                IdSolicitantes = idSolicitantes,
                Visualizado = visualizado,
                Paginacao = new PaginacaoViewModel(pagina, itensPorPagina)
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SolicitacaoPetViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<SolicitacaoPetViewModel>> Get(int id)
        {
            var query = new GetSolicitacaoPetQuery()
            {
                Id = id
            };

            return Ok(await Mediator.Send(query));
        }

        [HttpPost("Finalizar")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SolicitacaoPetViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequest))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ResponseUnauthorized))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<ActionResult<SolicitacaoPetViewModel>> Finalize(FinalizeSolicitacaoPet model)
        {
            var command = Mapper.Map<FinalizeSolicitacaoPetCommand>(model);

            return Ok(await Mediator.Send(command));
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ResponseNotFound))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ResponseBadRequest))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(ResponseUnauthorized))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(ResponseInternalServerError))]
        public async Task<IActionResult> Cancel(int id)
        {
            await Mediator.Send(new CancelSolicitacaoPetCommand() { Id = id });

            return NoContent();
        }
    }
}
