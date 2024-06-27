using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class GenreController : Controller
    {
        private readonly IVideoGames service;

        public GenreController(IVideoGames service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await service.GetAllAsync<Genre>();

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
