using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.SituacoesSolicitacaoPet.Models;
using PetOmetro.Application.SituacoesSolicitacaoPet.Queries.GetSituacoesSolicitacaoPet;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PetOmetro.API.Controllers
{
    public class SituacoesSolicitacaoPetController : BaseController
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<SituacaoSolicitacaoPetViewModel>))]
        public async Task<ActionResult<List<SituacaoSolicitacaoPetViewModel>>> GetAll([FromQuery] List<int> ids, [FromQuery]string nome)
        {
            var query = new GetSituacoesSolicitacaoPetQuery()
            {
                Ids = ids,
                Nome = nome
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
