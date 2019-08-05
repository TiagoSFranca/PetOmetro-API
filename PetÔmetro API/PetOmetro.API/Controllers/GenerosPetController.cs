using Microsoft.AspNetCore.Mvc;
using PetOmetro.Application.GenerosPet.Models;
using PetOmetro.Application.GenerosPet.Queries.GetGeneroPets;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PetOmetro.API.Controllers
{
    public class GenerosPetController : BaseController
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<GeneroPetViewModel>))]
        public async Task<ActionResult<List<GeneroPetViewModel>>> GetAll([FromQuery] List<int> ids, [FromQuery]string nome)
        {
            var query = new GetGenerosPetQuery()
            {
                Ids = ids,
                Nome = nome
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
