using Dapper;
using Nightfall.Application.Interfaces;
using Nightfall.Application.Models;
using Nightfall.Datastore.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightfall.Datastore.QueryHandlers
{
    public class ChampionQueryRepository : IChampionQueryRepository
    {
        private readonly string _connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["NightfallDB"].ToString();

        public async Task<IEnumerable<ChampionQuery>> GetAllDetails()
        {
            const string query = @" SELECT * FROM dbo.Champion;
                                    SELECT * FROM dbo.ChampionAbility;";

            using (var conn = new SqlConnection(_connectionStr))
            using (var multi = await conn.QueryMultipleAsync(query))
            {
                var champs = await multi.ReadAsync<ChampionRow>();
                var abilities = await multi.ReadAsync<AbilityRow>();

                return champs.Select(
                    champion =>
                        new ChampionQuery() {
                            Id = champion.Id,
                            Name = champion.Name,
                            CourageExpression = champion.CourageExpression,
                            FortitudeExpression = champion.FortitudeExpression,
                            Color = champion.Color,
                            Abilities = abilities
                                .Where(ability => ability.ChampionId == champion.Id)
                                .Select(
                                    ability =>
                                        new AbilityQuery()
                                        {
                                            Id = ability.Id,
                                            Description = ability.Description,
                                            Tier = ability.Tier
                                        })
                });
            }
        }
    }
}
