using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
