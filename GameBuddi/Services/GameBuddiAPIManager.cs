using Newtonsoft.Json;
using GameBuddi.Models;
using System.Net.Http.Json;

namespace GameBuddi.Services
{
    internal class GameBuddiAPIManager
    {
        // TODO: Add fields for BaseAddress, Url, and authorizationKey
        static readonly string BaseAddress = "https://gamebuddiapi.azurewebsites.net";
        static readonly string Url = $"{BaseAddress}/api/";

        static HttpClient client;

        private static HttpClient GetClient()
        {
            if (client != null)
                return client;

            client = new HttpClient();

            client.BaseAddress = new Uri(Url);

            //client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public static async Task<IEnumerable<User>> GetAllUsers()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new List<User>();

            HttpClient client = GetClient();
            string result = await client.GetStringAsync($"{Url}User");

            return JsonConvert.DeserializeObject<List<User>>(result);
        }
        public static async Task<IEnumerable<User>> GetUserReviews()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new List<User>();

            HttpClient client = GetClient();
            string result = await client.GetStringAsync($"{Url}User");

            return JsonConvert.DeserializeObject<List<User>>(result);
        }

        public static async Task<User> AddUser(string username, string email, string password)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new User();

            User user = new User()
            {
                Username = username,
                Email = email,
                Password = password
            };

            HttpClient client = GetClient();
            var msg = new HttpRequestMessage(HttpMethod.Post, $"{Url}parts");

            msg.Content = JsonContent.Create<User>(user);

            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode();

            var returnedJson = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<User>(returnedJson);
        }

        public static async Task UpdateUser(User user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return;

            HttpRequestMessage msg = new(HttpMethod.Put, $"{Url}User/{user.Id}");
            msg.Content = JsonContent.Create<User>(user);
            HttpClient client = GetClient();
            var response = await client.SendAsync(msg);
            response.EnsureSuccessStatusCode();
        }
    }
}