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
        private readonly AppDbContext _context;

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
                new Publisher(){ Id = 1, Publisher_Name = "EA Sports" },
                new Publisher(){ Id = 2, Publisher_Name = "CD Projekt Red" }
            };

            var games = new HashSet<Game>
            {
                new Game(){ Id = 1, GenreId = 1, Game_Name = "The Witcher", PublisherId = 2 },
                new Game(){ Id = 2, GenreId = 2, Game_Name = "Warcraft" , PublisherId = 1 }
            };

            /*var game_publishers = new HashSet<Game_Publisher>
            {
                new Game_Publisher(){ Id = 1, GameId = 1, PublisherId = 2 },
                new Game_Publisher(){ Id = 2, GameId = 2, PublisherId = 1 } // corrected the PublisherId to match seeded data
            };*/

            context.Genres.AddRange(genres);
            context.Games.AddRange(games);
            context.Publishers.AddRange(publishers);
            //context.Game_Publishers.AddRange(game_publishers);
            await context.SaveChangesAsync();
        }

        private async Task ClearData(AppDbContext context)
        {
            context.Genres.RemoveRange(context.Genres);
            context.Games.RemoveRange(context.Games);
            context.Publishers.RemoveRange(context.Publishers);
            //context.Game_Publishers.RemoveRange(context.Game_Publishers);
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

            var gameName = "Fifa";
            var genreId = 2;
            var Id = 1;

            var jsonContent = new StringContent($"{{\"Game_Name\": \"{gameName}\", \"GenreId\": \"{genreId}\", \"Id\": \"{Id}\"}}", Encoding.UTF8, "application/json");

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
