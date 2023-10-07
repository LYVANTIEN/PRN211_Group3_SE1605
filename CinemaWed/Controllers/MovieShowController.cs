using Microsoft.AspNetCore.Mvc;

namespace CinemaWed.Controllers
{
    public class MovieShowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
