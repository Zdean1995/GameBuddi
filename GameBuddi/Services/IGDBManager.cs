using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGDB;
using IGDB.Models;

namespace GameBuddi.Data
{
    public static class IGDBManager
    {
        static readonly string IGDB_CLIENT_ID = "42ogbeoxpizxz5drqmx94l6dsqg5zw";
        static readonly string IGDB_SECRET_ID = "hljej83qs386r3jedy594pe59r1vps";

        static IGDBClient client = new IGDBClient(IGDB_CLIENT_ID, IGDB_SECRET_ID);

        public static async Task<Game> GetGame(string id)
        {
            var games = await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields *; where id = {id};");
            return games.First();
        }

        public static async Task<Game[]> GetGames(string start)
        {
            return await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields name; limit 100;");

        }
    }
}
