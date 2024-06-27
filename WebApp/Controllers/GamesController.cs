using Infrastructure;
using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    
    public class GamesController : Controller
    {

        //private readonly ApiService _apiService;
        private readonly AppDbContext _appDbContext;
        private readonly IVideoGames _service;
        public GamesController(AppDbContext dbContext, IVideoGames service)
        {
            _appDbContext = dbContext;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? sortOrder,string genre, string publisher)
        {
            var items = await _appDbContext.Games.ToListAsync();
            var genres = await _appDbContext.Genres.ToListAsync();
            var publishers = await _appDbContext.Publishers.ToListAsync();

            ///sorting

            ViewBag.GameSortParm = sortOrder == "game" ? "game_desc" : "game";
            ViewBag.GenreSortParm = sortOrder == "genre" ? "genre_desc" : "genre";
            ViewBag.PublisherSortParm = sortOrder == "publisher" ? "publisher_desc" : "publisher";

            switch (sortOrder)
            {
                case "game_desc":
                    items = items.OrderByDescending(x => x.Game_Name).ToList();
                    break;
                case "game":
                    items = items.OrderBy(x => x.Game_Name).ToList();
                    break;
                case "genre_desc":
                    genres = genres.OrderByDescending(x => x.Genre_Name).ToList();
                    break;
                case "genre":
                    genres = genres.OrderBy(x => x.Genre_Name).ToList();
                    break;
                case "publisher_desc":
                    publishers = publishers.OrderByDescending(x => x.Publisher_Name).ToList();
                    break;
                case "publisher":
                    publishers = publishers.OrderBy(x => x.Publisher_Name).ToList();
                    break;

            }
            ///


            ///filtering
            ViewBag.genres = genres;
            ViewBag.publishers = publishers;

            if (!string.IsNullOrEmpty(genre))
                genres = await _appDbContext.Genres.Where(x => x.Genre_Name == genre).ToListAsync();

            if(!string.IsNullOrEmpty(publisher))
                publishers = await _appDbContext.Publishers.Where(x => x.Publisher_Name == publisher).ToListAsync();

            ///

            var query = items.GroupJoin(
                genres,
                game => game.GenreId,
                genre => genre.Id,
                (game, genreGroup) => new
                {
                    Game = game,
                    GenreName = genreGroup.FirstOrDefault()?.Genre_Name
                }
                ).Join(
                publishers,
                game => game.Game.PublisherId,
                publisher => publisher.Id,
                (game,publisherGroup) => new
                {
                    Game = game.Game,
                    GenreName = game.GenreName,
                    Publisher = game.Game.Publisher
                }
                )
                .Select(x => new GameVm
                {
                    Id = x.Game.Id,
                    Game_Name = x.Game.Game_Name,
                    Genre = x.GenreName,
                    Publisher = x.Publisher.Publisher_Name
                })
                .ToList();

            return View(query);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var genres = await _appDbContext.Genres.OrderBy(x => x.Genre_Name).Select(x => x.Genre_Name).Distinct().ToListAsync();
            var publishers = await _appDbContext.Publishers.OrderBy(x => x.Publisher_Name).Select(x => x.Publisher_Name).Distinct().ToListAsync();
            SelectList genres_Selectlist = new SelectList(genres);
            SelectList publishers_Selectlist = new SelectList(publishers);
            ViewBag.Genres = genres_Selectlist;
            ViewBag.Publishers = publishers_Selectlist;

            GameVm model = new GameVm();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(GameVm model)
        {

            var genre = await _appDbContext.Genres.FirstOrDefaultAsync(x => x.Genre_Name == model.Genre);
            var publisher = await _appDbContext.Publishers.FirstOrDefaultAsync(x => x.Publisher_Name == model.Publisher);
            if(genre == null)
            {
                Genre newGenre = new Genre()
                {
                    Genre_Name = model.Genre
                };
                await _appDbContext.Genres.AddAsync(newGenre);
                await _appDbContext.SaveChangesAsync();
            }

            if(publisher == null)
            {
                Publisher newPublisher = new Publisher()
                {
                    Publisher_Name = model.Publisher
                };
                await _appDbContext.Publishers.AddAsync(newPublisher);
                await _appDbContext.SaveChangesAsync();
            }

            Game entity = new Game()
            {
                Game_Name = model.Game_Name,
                Description = model.Description,
                GenreId = genre.Id,
                PublisherId = publisher.Id
            };
            await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            foreach (var platformItem in model.Platforms)
            {
                var platform = await _appDbContext.Platforms.FirstOrDefaultAsync(p => p.Platform_Name == platformItem.Name);
                if (platform == null) //if platform doesn't exists in database - add it
                {
                    platform = new Platform { Platform_Name = platformItem.Name };
                    _appDbContext.Platforms.Add(platform);
                    await _appDbContext.SaveChangesAsync();
                }
                var gamePlatform = new Game_Platform
                {
                    GameId = entity.Id,
                    PlatformId = platform.Id,
                    ReleaseYear = platformItem.ReleaseYear
                };
                await _appDbContext.Game_Platforms.AddAsync(gamePlatform);
            }

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _appDbContext.Games.FirstOrDefaultAsync(x => x.Id == id);
            
            if(item != null)
            { 
                var platforms = _appDbContext.Game_Platforms.Where(x => x.GameId == id);

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
                .Include(x => x.Publisher)
                .Include(x => x.Platforms)
                    .ThenInclude(p => p.Platform)
                .FirstOrDefaultAsync();

            ///Create Select lists
            
            var genres = await _appDbContext.Genres.OrderBy(x => x.Genre_Name).Select(x => x.Genre_Name).Distinct().ToListAsync();
            var publishers = await _appDbContext.Publishers.OrderBy(x => x.Publisher_Name).Select(x => x.Publisher_Name).Distinct().ToListAsync();
            SelectList genres_Selectlist = new SelectList(genres);
            SelectList publishers_Selectlist = new SelectList(publishers);
            ViewBag.Genres = genres_Selectlist;
            ViewBag.Publishers = publishers_Selectlist;

            ///

            if (game_item != null)
            {
                var game_publishers = game_item.Publisher;

                var platforms = game_item.Platforms;

                GameVm model = new GameVm
                {
                    Id = game_item.Id,
                    Game_Name = game_item.Game_Name,
                    Description = game_item.Description,
                    Genre = game_item.Genre?.Genre_Name,
                    Publisher = game_item.Publisher.Publisher_Name,
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
                .Include(x => x.Platforms)
                    .ThenInclude(x => x.Platform)
                .Include(x => x.Publisher)
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (ModelState.IsValid && entity != null)
            {
                var genre = await _appDbContext.Genres
                .FirstOrDefaultAsync(g => g.Genre_Name == model.Genre);

                var game_publisher = await _appDbContext.Publishers
                    .FirstOrDefaultAsync(x => x.Publisher_Name == model.Publisher);

                var game_platform = await _appDbContext.Game_Platforms
                    .FirstOrDefaultAsync(x => x.GameId == model.Id);


                entity.Game_Name = model.Game_Name;
                entity.Description = model.Description;
                entity.GenreId = genre.Id;


                entity.PublisherId = game_publisher.Id;


                entity.Platforms.Clear();
                foreach (var platformVm in model.Platforms)
                {
                    var platform = await _appDbContext.Platforms.FirstOrDefaultAsync(p => p.Platform_Name == platformVm.Name);
                    if (platform == null) //if platform doesn't exists in database - add it
                    {
                        platform = new Platform { Platform_Name = platformVm.Name };
                        _appDbContext.Platforms.Add(platform);
                        await _appDbContext.SaveChangesAsync();
                    }
                    //add the platform to the list
                    entity.Platforms.Add(new Game_Platform
                    {
                        GameId = entity.Id,
                        PlatformId = platform.Id,
                        ReleaseYear = platformVm.ReleaseYear
                    });
                }

                //_appDbContext.Games.Update(entity);
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
