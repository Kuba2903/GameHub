using API.DTO_s.User_RolesDTO_s;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVm model)
        {
            var response = await _apiService.LoginUserAsync(model);

            if (response)
                return RedirectToAction("CreateAccount");
            else
                return NotFound();
            
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
                return RedirectToAction("Index");
            else
                return NotFound();
        }
    }
}
