using Dapper;
using Nightfall.Application.Interfaces;
using Nightfall.Core;
using Nightfall.Datastore.Dto;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Nightfall.Datastore.QueryHandlers
{
    public class GamePersistenceHandler : IGamePersistenceHandler
    {
        private readonly string _connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["NightfallDB"].ToString();

        public async Task<Game> CreateGame(Game game)
        {
            const string query = @"INSERT INTO dbo.Game(Name) VALUES(@Name);
                                    SELECT Name FROM dbo.Game WHERE Id = SCOPE_IDENTITY();";

            GameRow row = GameRow.FromDomain(game);
            string result = "";
            using (var conn = new SqlConnection(_connectionStr))
            {
                result = (await conn.QueryAsync<string>(query, row)).First();
            }
            return await LoadGame(result);
        }

        public async Task<Game> LoadGame(string name)
        {
            const string query = @"SELECT * FROM dbo.Game WHERE Name = @name;";
            GameRow result;
            using (var conn = new SqlConnection(_connectionStr))
            {
                result = (await conn.QueryAsync<GameRow>(query, new { name = name })).First();
            }
            return result.ToDomain();
        }
    }
}
