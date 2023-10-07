using Microsoft.AspNetCore.Mvc;

namespace CinemaWed.Controllers
{
    public class TheaterHallController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
