using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightfall.Datastore.Dto
{
    public class AbilityRow
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ChampionId { get; set; }
        public int Tier { get; set; }
    }
}
