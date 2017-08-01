using Nightfall.Application.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Nightfall.API.Controllers
{
    [RoutePrefix("api/champions")]
    public class ChampionQueryController : ApiController
    {
        private readonly IChampionQueryRepository _championQueryRepository;

        public ChampionQueryController(IChampionQueryRepository queryRepository)
        {
            _championQueryRepository = queryRepository;
        }

        [Route("details")]
        public async Task<IHttpActionResult> GetDetails()
        {
            return Ok(await _championQueryRepository.GetAllDetails());
        }
    }
}