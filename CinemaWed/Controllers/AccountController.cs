using Microsoft.AspNetCore.Mvc;

namespace CinemaWed.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
