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
            const string query = @" SELECT * FROM dbo.Champion as c
                                    JOIN dbo.ColorScheme as s
                                    ON c.PrimaryColor = s.PrimaryColor;
                                    SELECT * FROM dbo.ChampionAbility;";

            using (var conn = new SqlConnection(_connectionStr))
            using (var multi = await conn.QueryMultipleAsync(query))
            {
                var champs = await multi.ReadAsync<dynamic>();
                var abilities = await multi.ReadAsync<AbilityRow>();

                return champs.Select(
                    champion =>
                        new ChampionQuery() {
                            Id = champion.Id,
                            Name = champion.Name,
                            CourageExpression = champion.CourageExpression,
                            FortitudeExpression = champion.FortitudeExpression,
                            Sigil = champion.Sigil,
                            Color = new ColorQuery()
                            {
                                PrimaryColor = champion.PrimaryColor,
                                LightAccent = champion.LightAccent,
                                DarkAccent = champion.DarkAccent,
                                LightComplement = champion.LightComplement,
                                DarkComplement = champion.DarkComplement
                            },
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
