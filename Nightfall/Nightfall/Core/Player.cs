using Nightfall.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightfall.Core
{
    public class Player
    {
        private string _name;
        private int _championId;
        private int _zoneId;
        private int _gameId;

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
        public int GameId
        {
            get { return _gameId; }
            set
            {
                if (value < 1)
                {
                    throw new ValidationException("Must provide a valid Game ID");
                }
                _gameId = value;
            }
        }

        private Player() { }

        public Player(string name, int championId, int zoneId, int gameId)
        {
            Name = name;
            ChampionId = championId;
            ZoneId = zoneId;
            GameId = gameId;
        }

        public static Player Reconstitute(int id, string name, int championId, int zoneId, int gameId)
        {
            return new Player()
            {
                Id = id,
                Name = name,
                ChampionId = championId,
                ZoneId = zoneId,
                GameId = gameId
            };
        }
    }
}
