using Infrastructure;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IVideoGames _service;
        private readonly AppDbContext _dbContext;

        public PublishersController(IVideoGames service, AppDbContext dbContext)
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
