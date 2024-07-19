using API.DTO_s.User_RolesDTO_s;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;

namespace WebApp
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();


        public async Task<string> GetStock(string ticker)
        {
            string apiKey = "WHSGHPXZ16LXB4NA";
            string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={ticker}&apikey={apiKey}";

            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return "";
        }

        public async Task<List<GameVm>> GetGamesAsync()
        {
            var response = await client.GetStringAsync("https://localhost:7155/api/VideoGames/getGames?pageSize=5&pageNumber=1");
            return JsonConvert.DeserializeObject<List<GameVm>>(response);
        }

        public async Task<bool> LoginUserAsync(LoginVm model)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7155/api/User/login", jsonContent);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }


        public async Task<bool> RegisterUserAsync(RegisterVm model)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7155/api/User/register", jsonContent);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
