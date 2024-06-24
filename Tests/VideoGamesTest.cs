using Infrastructure;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using API;
using System.Net;
using System.Text;
using API.DTO_s;

namespace Tests
{
    public class VideoGamesTest : IClassFixture<AppTest<Program>>
    {
        private readonly HttpClient _client;
        private readonly AppTest<Program> _app;

        public VideoGamesTest(AppTest<Program> app)
        {
            _app = app;
            _client = app.CreateClient();
        }

        private async Task SeedData(AppDbContext context)
        {
            var genres = new HashSet<Genre>
            {
                new Genre(){ Id = 1, Genre_Name = "RPG" },
                new Genre(){ Id = 2, Genre_Name = "RTS" }
            };

            var publishers = new HashSet<Publisher>
            {
                new Publisher(){ Id = 1, Publisher_Name = "Blizzard" },
                new Publisher(){ Id = 2, Publisher_Name = "CD Projekt Red" }
            };

            var games = new HashSet<Game>
            {
                new Game(){ Id = 1, GenreId = 1, Game_Name = "The Witcher", PublisherId = 2,
                Description = "RPG Adventure game"},
                new Game(){ Id = 2, GenreId = 2, Game_Name = "Warcraft" , PublisherId = 1,
                Description = "Fantasy game"}
            };


            context.Genres.AddRange(genres);
            context.Games.AddRange(games);
            context.Publishers.AddRange(publishers);

            await context.SaveChangesAsync();
        }

        private async Task ClearData(AppDbContext context)
        {
            context.Genres.RemoveRange(context.Genres);
            context.Games.RemoveRange(context.Games);
            context.Publishers.RemoveRange(context.Publishers);

            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetShouldReturnOkStatus()
        {
            using (var scope = _app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await ClearData(context);
                await SeedData(context);
            }

            var result = await _client.GetAsync("https://localhost:7155/api/VideoGames/getGames?pageSize=5&pageNumber=1");

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]

        public async Task CreateObject()
        {
            using (var scope = _app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await ClearData(context);
                await SeedData(context);
            }

            var genreName = "Action";
            var Id = 3;
            var jsonContent = new StringContent($"{{\"Id\": \"{Id}\", \"genre_Name\": \"{genreName}\"}}", Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://localhost:7155/api/VideoGames/addGenre", jsonContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]

        public async Task PutGames()
        {

            using (var scope = _app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await ClearData(context);
                await SeedData(context);
            }

            var gameName = "Warcraft";
            var genreId = 1;
            var Id = 2;
            string desc = "fantasy game";

            var jsonContent = new StringContent($"{{\"game_Name\": \"{gameName}\", \"genreId\": \"{genreId}\", \"id\": \"{Id}\", \"description\": \"{desc}\"}}", Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"https://localhost:7155/api/VideoGames/updateGame", jsonContent);
        

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }

        [Fact]
        public async Task GamesCount()
        {
            using (var scope = _app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await ClearData(context);
                await SeedData(context);
            }

            var response = await _client.GetAsync("https://localhost:7155/api/VideoGames/getGames?pageSize=5&pageNumber=1");
            response.EnsureSuccessStatusCode();

            var games = await response.Content.ReadFromJsonAsync<List<Game>>();

            Assert.Equal(2, games.Count);
        }


        [Fact]

        public async Task DeletePublishers()
        {
            using (var scope = _app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await ClearData(context);
                await SeedData(context);
            }
            int id = 2;
            var response = await _client.DeleteAsync($"https://localhost:7155/api/VideoGames/deletePublishers?id={id}");

            response.EnsureSuccessStatusCode();

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }
    }
}
