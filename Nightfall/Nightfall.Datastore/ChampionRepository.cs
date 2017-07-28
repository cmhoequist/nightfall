using Dapper;
using Nightfall.Datastore.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using Nightfall.Application;

namespace Nightfall.Datastore
{
    public class ChampionRepository: IChampionRepository
    {
        private readonly string _connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["NightfallDB"].ToString();

        public async Task<IEnumerable<Champion>> GetAll()
        {
            const string query = @"SELECT * FROM dbo.Champion";
            using (var conn = new SqlConnection(_connectionStr))
            {
                var result = await conn.QueryAsync<ChampionRow>(query);
                return result.Select(x => x.ToDomain());
            }
        }
    }
}
