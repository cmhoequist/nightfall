using Dapper;
using Nightfall.Application.Interfaces;
using Nightfall.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightfall.Datastore.QueryHandlers
{
    public class ZonePersistenceHandler : IZonePersistenceHandler
    {
        private readonly string _connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["NightfallDB"].ToString();

        public async Task<IEnumerable<ZoneQuery>> GetAll()
        {
            const string query = @"SELECT * FROM Zone;";
            using (var conn = new SqlConnection(_connectionStr))
            {
                var result = await conn.QueryAsync<dynamic>(query);
                return result.Select(zone =>
                    new ZoneQuery()
                    {
                        Id = zone.Id,
                        Name = zone.Name
                    }
                );
            }
        }
    }
}
