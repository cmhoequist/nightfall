using Nightfall.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightfall.Datastore.Dto
{
    class GameRow
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private GameRow() { }

        public static GameRow FromDomain(Game game)
        {
            return new GameRow()
            {
                Id = game.Id,
                Name = game.Name
            };
        }

        public Game ToDomain()
        {
            return Game.Reconstitute(Id, Name);
        }
    }
}
