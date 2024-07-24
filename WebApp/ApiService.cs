using API.DTO_s.User_RolesDTO_s;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                var json = JObject.Parse(responseBody);

                // Extract the latest stock market value
                var timeSeries = json["Time Series (Daily)"];
                var latestEntry = timeSeries.First as JProperty;
                if (latestEntry != null)
                {
                    var latestDate = latestEntry.Name;
                    var latestData = latestEntry.Value;

                    var closingPrice = latestData["4. close"].ToString();
                    return $"Stock value for {ticker} on {latestDate}: {closingPrice}";
                }
                else
                {
                    return "No time series data found.";
                }
            }
            catch (HttpRequestException e)
            {
                return "No time series data found.";
            }
        }

        public async Task<List<GameVm>> GetGamesAsync()
        {
            var response = await client.GetStringAsync("https://localhost:7155/api/VideoGames/getGames?pageSize=5&pageNumber=1");
            return JsonConvert.DeserializeObject<List<GameVm>>(response);
        }
    }
}
