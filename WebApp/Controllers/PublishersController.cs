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
    public class PublishersController : Controller
    {
        private readonly IVideoGames _service;
        private readonly AppDbContext _dbContext;
        private readonly ApiService _api;

        public PublishersController(IVideoGames service, AppDbContext dbContext, ApiService api)
        {
            _service = service;
            _dbContext = dbContext;
            _api = api;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder)
        {
            var entities = await _service.GetAllAsync<Publisher>();

            ViewBag.PublisherSortParm = sortOrder == "publisher" ? "publisher_desc" : "publisher";

            switch (sortOrder)
            {
                case "publisher":
                    entities = entities.OrderBy(x => x.Publisher_Name);
                    break;
                case "publisher_desc":
                    entities = entities.OrderByDescending(x => x.Publisher_Name);
                    break;
            }

            var query = entities.Select(x => new PublisherVm
            {
                Id = x.Id,
                Name = x.Publisher_Name
            }).ToList();

            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PublisherVm model = new PublisherVm();
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Create(PublisherVm model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Publisher() { Publisher_Name = model.Name, StockSymbol = model.StockSymbol };

                await _service.AddAsync<Publisher>(entity);
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
            var item = await _service.FindByIdAsync<Publisher>(id);

            if (item != null)
            {
                PublisherVm model = new PublisherVm { Id = item.Id, Name = item.Publisher_Name, StockSymbol = item.StockSymbol };
                return View(model);
            }
            else
                return View();
        }


        [HttpPost]

        public async Task<IActionResult> Edit(PublisherVm model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _service.FindByIdAsync<Publisher>(model.Id);
                entity.Publisher_Name = model.Name;
                entity.StockSymbol = model.StockSymbol;
                await _service.UpdateAsync<Publisher>(entity);

                return RedirectToAction("Index");
            }
            return View(model);

        }


        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _service.FindByIdAsync<Publisher>(id);

            if (entity != null)
            {
                PublisherVm model = new PublisherVm { Id = entity.Id, Name = entity.Publisher_Name };
                return View(model);
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> DeleteConfirm(PublisherVm model)
        {
            var entity = await _service.FindByIdAsync<Publisher>(model.Id);

            await _service.RemoveAsync<Publisher>(entity);

            return RedirectToAction("Index");
        }


        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _service.FindByIdAsync<Publisher>(id);

            var query = _dbContext.Games.Include(x => x.Publisher)
                .Where(x => x.Publisher.Publisher_Name == entity.Publisher_Name).Select(x => x.Game_Name);

            var stock = await _api.GetStock(entity.StockSymbol);

            ViewBag.PublisherName = entity.Publisher_Name;
            ViewBag.Stock = stock;

            return View(query);
        }
    }
}
