using Infrastructure;
using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

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

        public async Task<IActionResult> Index(string sortOrder)
        {
            var items = await _service.GetAllAsync<Platform>();

            ViewBag.PlatformSortParm = sortOrder == "name" ? "name_desc" : "name";

            switch (sortOrder)
            {
                case "name":
                    items = items.OrderBy(x => x.Platform_Name);
                    break;
                case "name_desc":
                    items = items.OrderByDescending(x => x.Platform_Name);
                    break;
            }

            var query = items.Select(x => new PlatformVm
            {
                Id = x.Id,
                Name = x.Platform_Name
            }).ToList();

            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PlatformVm model = new PlatformVm();
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Create(PlatformVm model)
        {
            if(ModelState.IsValid)
            {
                var entity = new Platform() { Platform_Name = model.Name };

                await _service.AddAsync<Platform>(entity);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
