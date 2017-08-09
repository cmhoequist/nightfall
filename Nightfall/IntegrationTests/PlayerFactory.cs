using Nightfall.Application.Commands;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class PlayerFactory
    {
        private QueryHelper _queryHelper;
        private IFixture _fixture;

        public PlayerFactory(QueryHelper helper)
        {
            _queryHelper = helper;
            _fixture = new Fixture();
        }

        public AddPlayerCommand CreateAddPlayerCommand()
        {
            return new AddPlayerCommand()
            {
                Name = _fixture.Create<string>(),
                ChampionId = _queryHelper.GetArbitraryChampionId(),
                ZoneId = _queryHelper.GetArbitraryZoneId(),
                GameId = _queryHelper.GetArbitraryGameId()
            };
        }
    }
}
