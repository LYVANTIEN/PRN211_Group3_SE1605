using Microsoft.AspNetCore.Mvc;

namespace CinemaWed.Controllers
{
    public class SeatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
