using System;
using System.Collections.Generic;
using System.Text;

namespace Nightfall.Application.Commands
{
    public class AddPlayerCommand
    {
        public string Name { get; set; }
        public int ChampionId { get; set; }
        public int ZoneId { get; set; }
        public int GameId { get; set; }
    }
}
