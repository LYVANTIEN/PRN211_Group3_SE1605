using Microsoft.AspNetCore.Mvc;

namespace CinemaWed.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
