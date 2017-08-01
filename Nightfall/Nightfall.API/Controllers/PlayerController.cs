using Nightfall.Application.Commands;
using Nightfall.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Nightfall.API.Controllers
{
    [RoutePrefix("api/players")]
    public class PlayerController: ApiController
    {
        private readonly IPlayerPersistenceHandler _playerPersistence;

        public PlayerController(IPlayerPersistenceHandler playerPersistence)
        {
            _playerPersistence = playerPersistence;
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Save(AddPlayerCommand player)
        {
            return Ok(await _playerPersistence.Save(new Player(player.Name, player.ChampionId, player.ZoneId)));
        }
    }
}