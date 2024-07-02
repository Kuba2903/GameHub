using Infrastructure;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly IVideoGames _service;
        private readonly AppDbContext _dbContext;

        public PlatformsController(IVideoGames service, AppDbContext dbContext)
        {
            _service = service;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
