using Nightfall.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nightfall.Application.Commands;
using System.Data.SqlClient;
using Nightfall.Datastore.Dto;
using Dapper;
using Nightfall.Core;

namespace Nightfall.Datastore.QueryHandlers
{
    public class PlayerPersistenceHandler : IPlayerPersistenceHandler
    {
        private readonly string _connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["NightfallDB"].ToString();

        public async Task<Player> Save(Player player)
        {
            const string query = @"INSERT INTO dbo.Player (Name, ZoneId, ChampionId, GameId)
                                    VALUES
                                    (@Name, @ZoneId, @ChampionId, @GameId);
                                    SELECT SCOPE_IDENTITY();";

            PlayerRow row = PlayerRow.FromDomain(player);
            int id = row.Id;
            using (var conn = new SqlConnection(_connectionStr))
            {
                id = (await conn.QueryAsync<int>(query, row)).First();
            }
            return await GetById(id);
        }

        public async Task<Player> GetById(int id)
        {
            const string query = @"SELECT * FROM dbo.Player WHERE Id = @id;";
            PlayerRow result;
            using (var conn = new SqlConnection(_connectionStr))
            {
                result = (await conn.QueryAsync<PlayerRow>(query, new { id = id })).First();
            }
            return result.ToDomain();
        }

        public async Task<Player> GetByName(string name)
        {
            const string query = @"SELECT * FROM dbo.Player WHERE Name = @name;";
            PlayerRow result;
            using (var conn = new SqlConnection(_connectionStr))
            {
                result = (await conn.QueryAsync<PlayerRow>(query, new { name = name })).First();
            }
            return result.ToDomain();
        }
    }
}
