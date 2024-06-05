using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models;

namespace WebApp
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<GameVm>> GetGamesAsync()
        {
            var response = await client.GetStringAsync("https://localhost:7155/api/VideoGames/getGames?pageSize=5&pageNumber=1");
            return JsonConvert.DeserializeObject<List<GameVm>>(response);
        }

        /*public async Task LoginUserAsync(string model)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7155/api/User/login", jsonContent);
        }*/
    }
}
