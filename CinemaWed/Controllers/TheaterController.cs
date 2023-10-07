using Microsoft.AspNetCore.Mvc;

namespace CinemaWed.Controllers
{
    public class TheaterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
