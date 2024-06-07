using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    
    public class GamesController : Controller
    {

        private readonly ApiService _apiService;
        private readonly AppDbContext _appDbContext;
        public GamesController(ApiService apiService, AppDbContext dbContext)
        {
            _apiService = apiService;
            _appDbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _appDbContext.Games.ToListAsync();
            var genres = await _appDbContext.Genres.ToListAsync();


            var query = items.Join(
                genres,
                game => game.GenreId,
                genre => genre.Id,
                (game, genre) => new GameVm
                {
                    Id = game.Id,
                     Game_Name = game.Game_Name,
                      Genre = genre.Genre_Name,
                }).ToList();

            return View(query);
        }
    }
}
