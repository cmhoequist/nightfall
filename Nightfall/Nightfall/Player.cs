using Nightfall.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightfall
{
    public class Player
    {
        private string _name;
        private int _championId;
        private int _zoneId;

        public int Id { get; private set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ValidationException("Must provide a Player Name");
                }
                _name = value;
            }
        }
        public int ChampionId {
            get { return _championId; }
            set
            {
                if(value < 1)
                {
                    throw new ValidationException("Must provide a valid Champion ID");
                }
                _championId = value;
            }
        }
        public int ZoneId
        {
            get { return _zoneId; }
            set
            {
                if (value < 1)
                {
                    throw new ValidationException("Must provide a valid Zone ID");
                }
                _zoneId = value;
            }
        }

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
