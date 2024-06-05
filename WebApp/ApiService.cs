using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
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
    }
}
