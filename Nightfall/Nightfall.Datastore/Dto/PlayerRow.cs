using Nightfall.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightfall.Datastore.Dto
{
    class PlayerRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChampionId { get; set; }
        public int ZoneId { get; set; }
        public int GameId { get; set; }

        private PlayerRow() { }

        public static PlayerRow FromDomain(Player player)
        {
            return new PlayerRow()
            {
                Id = player.Id,
                Name = player.Name,
                ChampionId = player.ChampionId,
                ZoneId = player.ZoneId,
                GameId = player.GameId
            };
        }

        public Player ToDomain()
        {
            return Player.Reconstitute(Id, Name, ChampionId, ZoneId, GameId);
        }
    }
}
