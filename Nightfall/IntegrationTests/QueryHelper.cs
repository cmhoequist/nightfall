using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class QueryHelper
    {
        private readonly string _connectionStr;

        public QueryHelper(string connStr)
        {
            _connectionStr = connStr;
        }

        public int GetHighestPlayerId()
        {
            using (var conn = new SqlConnection(_connectionStr))
            {
                return conn.Query<int>("select top 1 Id from Player order by Id desc").FirstOrDefault();
            }
        }

        public int GetArbitraryZoneId()
        {
            using (var conn = new SqlConnection(_connectionStr))
            {
                return conn.Query<int>("select top 1 Id from Zone order by Id desc").FirstOrDefault();
            }
        }

        public int GetArbitraryChampionId()
        {
            using (var conn = new SqlConnection(_connectionStr))
            {
                return conn.Query<int>("select top 1 Id from Champion order by Id desc").FirstOrDefault();
            }
        }

        public int GetArbitraryGameId()
        {
            using (var conn = new SqlConnection(_connectionStr))
            {
                return conn.Query<int>("select top 1 Id from Game order by Id desc").FirstOrDefault();
            }
        }

        public void DeletePlayer(int id)
        {
            using (var conn = new SqlConnection(_connectionStr))
            {
                conn.Execute("Delete Player where Id = @id", new { id });
            }
        }
    }
}
