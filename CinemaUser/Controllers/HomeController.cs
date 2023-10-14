using BusinessObject.Repository;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWed.Controllers
{
    public class HomeController : Controller
    {
        IMovieRepository movieRepository;

        public HomeController() { movieRepository = new MovieRepository(); }
        public ActionResult Index()
        {
            var movie = movieRepository.GetMovie();
            return View(movie);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = movieRepository.GetMovieById(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
    }
}
