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


        [HttpPost]
        public async Task<IActionResult> Edit(GameVm model)
        {
            var entity = await _appDbContext.Games
                .Include(x => x.Genre)
                .Include(x => x.Games_Publishers)
                    .ThenInclude(gp => gp.Game_Platforms)
                    .ThenInclude(gp => gp.Platform)
                .Include(x => x.Games_Publishers)
                    .ThenInclude(gp => gp.Publisher)
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (ModelState.IsValid && entity != null)
            {
                var genre = await _appDbContext.Genres
                .FirstOrDefaultAsync(g => g.Genre_Name == model.Genre);

                var game_publisher = await _appDbContext.Game_Publishers
                    .FirstOrDefaultAsync(x => x.GameId == model.Id);

                var game_platform = await _appDbContext.Game_Platforms
                    .FirstOrDefaultAsync(x => x.Game_PublisherId == game_publisher.Id);


                entity.Game_Name = model.Game_Name;
                entity.Description = model.Description;
                entity.Genre.Genre_Name = genre.Genre_Name;
                entity.GenreId = genre.Id;
                if (!entity.Games_Publishers.Contains(game_publisher))
                    entity.Games_Publishers.Add(game_publisher);
                
                var existingPublisher = entity.Games_Publishers.FirstOrDefault();
                if (existingPublisher == null)
                {
                    existingPublisher = new Game_Publisher
                    {
                        Publisher = new Publisher { Publisher_Name = model.Publisher },
                        GameId = model.Id
                    };
                    entity.Games_Publishers.Add(existingPublisher);
                }
                else
                {
                    existingPublisher.Publisher.Publisher_Name = model.Publisher; 
                }

                existingPublisher.Game_Platforms.Clear();

                foreach (var platformVm in model.Platforms)
                {
                    var platform = await _appDbContext.Platforms.FirstOrDefaultAsync(p => p.Platform_Name == platformVm.Name);
                    if (platform == null)
                    {
                        platform = new Platform { Platform_Name = platformVm.Name };
                        _appDbContext.Platforms.Add(platform);
                        await _appDbContext.SaveChangesAsync();
                    }

                    existingPublisher.Game_Platforms.Add(new Game_Platform
                    {
                        Game_PublisherId = existingPublisher.Id,
                        PlatformId = platform.Id,
                        ReleaseYear = platformVm.ReleaseYear
                    });
                }

                _appDbContext.Games.Update(entity);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
