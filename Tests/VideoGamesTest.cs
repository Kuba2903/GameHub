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

            using(var scope = app.Services.CreateScope())
            {
                _context = scope.ServiceProvider.GetService<AppDbContext>();

                var genres = new HashSet<Genre>
                {
                    new Genre(){Id = 1 ,Genre_Name = "RPG" },
                    new Genre(){Id = 2 ,Genre_Name = "RTS" }
                };

                var games = new HashSet<Game>
                {
                    new Game(){Id = 1 , GenreId = 1, Game_Name = "The Witcher" },
                    new Game(){Id = 2 ,GenreId = 2, Game_Name = "Warcraft" }
                };

                var publishers = new HashSet<Publisher>
                {
                    new Publisher(){Id = 1, Publisher_Name = "EA Sports" },
                    new Publisher(){Id = 2, Publisher_Name = "CD Projekt Red" }
                };

                var game_publishers = new HashSet<Game_Publisher>
                {
                    new Game_Publisher() { Id = 1, GameId = 1, PublisherId =  2},
                    new Game_Publisher() {Id = 2, GameId = 2, PublisherId = 3}
                };

                _context.SaveChanges();
            }
        }

        [Fact]

        public async Task GetShouldReturnOkStatus()
        {
            var result = await _client.GetAsync("https://localhost:7155/api/VideoGames/getGames?pageSize=5&pageNumber=1");
       
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]

        public async Task CreateObject()
        {
            var genreName = "Action";
            var jsonContent = new StringContent($"{{\"genre_Name\": \"{genreName}\"}}", Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://localhost:7155/api/VideoGames/addGenre", jsonContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]

        public async Task PutGames()
        {
            var gameName = "Fifa";
            var genreId = 2;

            var jsonContent = new StringContent($"{{\"Game_Name\": \"{gameName}\", \"GenreId\": \"{genreId}\"}}", Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"https://localhost:7155/api/VideoGames/updateGame", jsonContent);
        

            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }

        [Fact]

        public async Task DeletePublisher()
        {
            int id = 1;

            var response = await _client.DeleteAsync($"https://localhost:7155/api/VideoGames/deletePublishers?id={id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
