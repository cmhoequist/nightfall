using Nightfall.Application;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Nightfall.API.Controllers
{
    [RoutePrefix("api/champions")]
    public class ChampionController : ApiController
    {
        private readonly IChampionRepository _repository;

        public ChampionController(IChampionRepository repository)
        {
            _repository = repository;
        }

        [Route("all")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _repository.GetAll());
        }
    }
}