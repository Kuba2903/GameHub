using Infrastructure;
using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GenresController : Controller
    {
        private readonly IVideoGames service;
        private readonly AppDbContext dbContext;
        public GenresController(IVideoGames service, AppDbContext dbContext)
        {
            this.service = service;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            var genres = await service.GetAllAsync<Genre>();

            //sorting
            ViewBag.GenreSortParm = sortOrder == "genre" ? "genre_desc" : "genre";

            switch (sortOrder)
            {
                case "genre_desc":
                    genres = genres.OrderByDescending(x => x.Genre_Name).ToList();
                    break;
                case "genre":
                    genres = genres.OrderBy(x => x.Genre_Name).ToList();
                    break;
            }
            //


            var query = genres.Select(x => new GenreVm
            {
                Id = x.Id,
                Genre_Name = x.Genre_Name
            }
            ).ToList();

            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GenreVm model = new GenreVm();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreVm model)
        {
            var isExisting = await dbContext.Genres.FirstOrDefaultAsync(x => x.Genre_Name == model.Genre_Name);

            if(isExisting == null)
            {
                Genre entity = new Genre()
                {
                    Genre_Name = model.Genre_Name,
                };
                await service.AddAsync<Genre>(entity);
            }
            else
            {
                return View(model);
            }
            
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await service.FindByIdAsync<Genre>(id);
            var model = new GenreVm() { Id = id, Genre_Name = item.Genre_Name };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var item = await service.FindByIdAsync<Genre>(id);

            if(item != null)
            {
                await service.RemoveAsync<Genre>(item);
            }
            else
            {
                return View(item);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await service.FindByIdAsync<Genre>(id);

            if (item != null)
            {
                GenreVm model = new GenreVm { Id = item.Id, Genre_Name = item.Genre_Name };
                return View(model);
            }
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Edit(GenreVm model)
        {
            var item = await service.FindByIdAsync<Genre>(model.Id);

            if(item != null)
            {
                item.Genre_Name = model.Genre_Name;
                await service.UpdateAsync<Genre>(item);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var item = await service.FindByIdAsync<Genre>(id);

            if(item != null)
            {
                var games = await 
                    dbContext.Games.Include(x => x.Genre)
                    .Where(x => x.Genre.Genre_Name == item.Genre_Name).ToListAsync();

                ViewBag.GenreName = item.Genre_Name;

                return View(games);
            }

            return View();
        }
    }
}
