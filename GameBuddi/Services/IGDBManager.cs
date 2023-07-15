using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGDB;
using IGDB.Models;

namespace GameBuddi.Services
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
            return await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields id, name; where id >= {start}; limit 100;");
        }
        public static async Task<Game[]> GetGamesSearch(string searchText)
        {
            return await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields id, name; where name = {searchText};");
        }

        public static async Task<InvolvedCompany[]> GetGamesCompanies(Game game)
        {
            return await client.QueryAsync<InvolvedCompany>(IGDBClient.Endpoints.InvolvedCompanies, query: $"fields developer, publisher, company.*; where game = {game.Id};");
        }

        public static async Task<Company> GetCompany(string id)
        {
            var companies = await client.QueryAsync<Company>(IGDBClient.Endpoints.Companies, query: $"fields *; where id = {id}");
            return companies.First();
        }
        public static async Task<Company[]> GetCompanies(string start)
        {
            return await client.QueryAsync<Company>(IGDBClient.Endpoints.Companies, query: $"fields id, name;  where id >= {start}; limit 100;");
        }
        public static async Task<Company[]> GetCompaniesSearch(string searchText)
        {
            return await client.QueryAsync<Company>(IGDBClient.Endpoints.Companies, query: $"fields id, name; where name = {searchText};");
        }

        public static async Task<Game[]> GetCompaniesGames(Company company)
        {
            List<long> gameIds = new List<long>();
            if (company.Published != null)
            {
                gameIds.AddRange(company.Published.Ids);
            }
            if (company.Developed != null)
            {
                gameIds.AddRange(company.Developed.Ids.Except(gameIds));
            }

            if (gameIds.Any())
            {
                return await client.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields *; where id = ({string.Join(',', gameIds)});");
            }
            else
            {
                return Array.Empty<Game>();
            }
        }
    }
}
