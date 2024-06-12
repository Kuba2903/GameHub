using Infrastructure;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
            var publishers = await _appDbContext.Publishers.ToListAsync();
            var game_publisher = await _appDbContext.Game_Publishers.ToListAsync();

            var query = items.GroupJoin(
                genres,
                game => game.GenreId,
                genre => genre.Id,
                (game, genreGroup) => new
                {
                    Game = game,
                    GenreName = genreGroup.FirstOrDefault()?.Genre_Name
                }
                )
                .Join(
                    game_publisher,
                    g => g.Game.Id,
                    gp => gp.GameId,
                    (g, gp) => new
                    {
                        g.Game,
                        g.GenreName,
                        gp.PublisherId,
                        GamePublisherId = gp.Id
                    }
                )
                .Join(
                    publishers,
                    gp => gp.PublisherId,
                    p => p.Id,
                    (gp, p) => new
                    {
                        gp.Game,
                        gp.GenreName,
                        PublisherName = p.Publisher_Name,
                        gp.GamePublisherId
                    }
                )
                .Select(x => new GameVm
                {
                     Id = x.Game.Id,
                     Game_Name = x.Game.Game_Name,
                     Genre = x.GenreName,
                     Publisher = x.PublisherName
                })
                .ToList();

            return View(query);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _appDbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
            
            if(item != null)
            { 
                var platforms = _appDbContext.Game_Platforms.Where(x => x.Game_PublisherId == id);

                GameVm query = new GameVm()
                {
                    Id = item.Id,
                    Game_Name = item.Game_Name,
                    Description = item.Description,
                    Platforms = platforms.Select(x => new PlatformsVm
                    {
                        Name = x.Platform.Platform_Name,
                        ReleaseYear = x.ReleaseYear
                    }).ToList()
                };

                /*var query = platforms.Select(x => new GameVm
                {
                    Id = item.Id,
                    Game_Name = item.Game_Name,
                    Description = item.Description,
                    Platforms = platforms.Select(x => new PlatformsVm
                    {
                        Name = x.Platform.Platform_Name,
                        ReleaseYear = x.ReleaseYear
                    }).ToList()
                });*/

                return View(query);
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _appDbContext.Games.FirstOrDefaultAsync(x => x.Id == id);

            if(item != null)
            {
                GameVm model = new GameVm
                {
                    Id = item.Id,
                    Game_Name = item.Game_Name
                };

                return View(model);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var item = await _appDbContext.Games.FirstOrDefaultAsync(x => x.Id == id);

            if(item != null)
            {
                _appDbContext.Games.Remove(item);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var game_item = await _appDbContext.Games
                .Where(x => x.Id == id)
                .Include(x => x.Genre)
                .Include(x => x.Games_Publishers)
                    .ThenInclude(gp => gp.Publisher)
                .Include(x => x.Games_Publishers)
                    .ThenInclude(y => y.Game_Platforms)
                    .ThenInclude(p => p.Platform)
                .FirstOrDefaultAsync();

            if (game_item != null)
            {
                var game_publishers = game_item.Games_Publishers.FirstOrDefault();

                var platforms = game_publishers.Game_Platforms;

                GameVm model = new GameVm
                {
                    Id = game_item.Id,
                    Game_Name = game_item.Game_Name,
                    Description = game_item.Description,
                    Genre = game_item.Genre?.Genre_Name,
                    Publisher = game_item.Games_Publishers?.FirstOrDefault()?.Publisher?.Publisher_Name,
                    Platforms = platforms.Select(x => new PlatformsVm
                    {
                        Name = x.Platform.Platform_Name,
                        ReleaseYear = x.ReleaseYear
                    }).ToList()
                };
                return View(model);
            }

            return View();
        }
    }
}
