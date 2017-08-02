using Nightfall.Application.Commands;
using Nightfall.Application.Interfaces;
using Nightfall.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Nightfall.API.Controllers
{
    [RoutePrefix("api/games")]
    public class GameController : ApiController
    {
        private readonly IGamePersistenceHandler _gamePersistenceHandler;

        public GameController(IGamePersistenceHandler gamePersistenceHandler)
        {
            _gamePersistenceHandler = gamePersistenceHandler;
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> CreateGame(AddGameCommand game)
        {
            return Ok(await _gamePersistenceHandler.CreateGame(new Game(game.Name)));
        }
    }
}