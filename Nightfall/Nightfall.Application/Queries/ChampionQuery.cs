using System;
using System.Collections.Generic;
using System.Text;

namespace Nightfall.Application.Models
{
    public class ChampionQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourageExpression { get; set; }
        public string FortitudeExpression { get; set; }
        public string Sigil { get; set; }
        public ColorQuery Color { get; set; }
        public IEnumerable<AbilityQuery> Abilities { get; set; }

        public ChampionQuery() { }
    }
}
