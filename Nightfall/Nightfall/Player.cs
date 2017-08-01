using System;
using System.Collections.Generic;
using System.Text;

namespace Nightfall
{
    public class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int ChampionId { get; private set; }
        public int ZoneId { get; private set; }

        private Player() { }

        public Player(string name, int championId, int zoneId)
        {
            Name = name;
            ChampionId = championId;
            ZoneId = zoneId;
        }

        public static Player Reconstitute(int id, string name, int championId, int zoneId)
        {
            return new Player()
            {
                Id = id,
                Name = name,
                ChampionId = championId,
                ZoneId = zoneId
            };
        }
    }
}
