using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GenresController : Controller
    {
        private readonly IVideoGames service;

        public GenresController(IVideoGames service)
        {
            this.service = service;
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
    }
}
