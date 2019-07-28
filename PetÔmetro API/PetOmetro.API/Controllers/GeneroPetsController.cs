using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.GeneroPets.Models;
using PetOmetro.Application.GeneroPets.Queries.GetGeneroPets;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PetOmetro.API.Controllers
{
    public class GeneroPetsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<GeneroPetViewModel>))]
        public async Task<ActionResult<List<GeneroPetViewModel>>> GetAll([FromQuery] List<int> ids, [FromQuery]string nome)
        {
            var query = new GetGeneroPetsQuery()
            {
                Ids = ids,
                Nome = nome
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
