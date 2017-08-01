﻿using Nightfall.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nightfall.Application.Commands;
using System.Data.SqlClient;
using Nightfall.Datastore.Dto;
using Dapper;

namespace Nightfall.Datastore.QueryHandlers
{
    public class PlayerPersistenceHandler : IPlayerPersistenceHandler
    {
        private readonly string _connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["NightfallDB"].ToString();

        public async Task<Player> Save(Player player)
        {
            const string query = @"INSERT INTO dbo.Player (Name, ZoneId, ChampionId)
                                    VALUES
                                    (@Name, @ZoneId, @ChampionId);";

            PlayerRow row = PlayerRow.FromDomain(player);
            int results = row.Id;
            using (var conn = new SqlConnection(_connectionStr))
            {
                results = (await conn.QueryAsync<int>(query, row)).First();
            }
            return await GetById(results);
        }

        public async Task<Player> GetById(int id)
        {
            const string query = @"SELECT * FROM dbo.Player WHERE Id = @id;";
            PlayerRow result;
            using (var conn = new SqlConnection(_connectionStr))
            {
                result = (await conn.QueryAsync<PlayerRow>(query, id)).First();
            }
            return result.ToDomain();
        }
    }
}
