using API.DTO_s.User_RolesDTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;

        public HomeController(ApiService apiService)
        {
            _apiService = apiService;
        }


        [HttpGet]
        public IActionResult Index(string? name)
        {
            ViewBag.name = name;
            return View();
        }

        [HttpGet]
        public IActionResult LoginAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAccount(LoginVm model)
        {
            var response = await _apiService.LoginUserAsync(model);

            if (response)
                return RedirectToAction("Index", new { name = model.Login });
            else
                return View(model);
            
        }

        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(RegisterVm model)
        {
            var response = await _apiService.RegisterUserAsync(model);

            if (response && model.Password == model.ConfirmPassword)
                return RedirectToAction("Index", new {name = model.Login});
            else
                return View(model);
        }


        [HttpGet]
        public IActionResult Sign_Out()
        {
            ViewBag.name = null;
            return View("Index");
        }
    }
}
