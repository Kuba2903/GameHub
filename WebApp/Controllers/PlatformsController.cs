using Infrastructure;
using Infrastructure.Entities;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class PlatformsController : Controller
    {
        private readonly IVideoGames _service;
        private readonly AppDbContext _dbContext;

        public PlatformsController(IVideoGames service, AppDbContext dbContext)
        {
            _service = service;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
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


        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _service.FindByIdAsync<Platform>(id);

            if (item != null)
            {
                PlatformVm model = new PlatformVm { Id = item.Id, Name = item.Platform_Name };
                return View(model);
            }
            else
                return View();
        }


        [HttpPost]

        public async Task<IActionResult> Edit(PlatformVm model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _service.FindByIdAsync<Platform>(model.Id);
                entity.Platform_Name = model.Name;
                await _service.UpdateAsync<Platform>(entity);

                return RedirectToAction("Index");
            }
            return View(model);

        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _service.FindByIdAsync<Platform>(id);

            if(entity != null)
            {
                PlatformVm model = new PlatformVm { Id = entity.Id, Name = entity.Platform_Name };
                return View(model);
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirm(PlatformVm model)
        {
            var entity = await _service.FindByIdAsync<Platform>(model.Id);
            
            await _service.RemoveAsync<Platform>(entity);

            return RedirectToAction("Index");
        }


        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _service.FindByIdAsync<Platform>(id);

            var query = _dbContext.Game_Platforms.Include(x => x.Platform).Include(x => x.Game)
                .Where(x => x.Platform.Platform_Name == entity.Platform_Name).Select(x => x.Game.Game_Name);

            ViewBag.PlatformName = entity.Platform_Name;

            return View(query);
        }
    }
}
