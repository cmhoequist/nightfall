using Nightfall.Application.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Nightfall.API.Controllers
{
    [RoutePrefix("api/champions")]
    public class ChampionController : ApiController
    {
        private readonly IChampionRepository _championRepository;
        private readonly IChampionQueryRepository _championQueryRepository;

        public ChampionController(IChampionRepository repository, IChampionQueryRepository queryRepository)
        {
            _championRepository = repository;
            _championQueryRepository = queryRepository;
        }

        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _championRepository.GetAll());
        }

        [Route("details")]
        public async Task<IHttpActionResult> GetDetails()
        {
            return Ok(await _championQueryRepository.GetAllDetails());
        }
    }
}