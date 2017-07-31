using Nightfall.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Nightfall.API.Controllers
{
    [RoutePrefix("api/zones")]
    public class ZoneController : ApiController
    {
        private readonly IZonePersistenceHandler _zoneHandler;

        public ZoneController(IZonePersistenceHandler zoneHandler)
        {
            _zoneHandler = zoneHandler;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await _zoneHandler.GetAll());
        }
    }
}