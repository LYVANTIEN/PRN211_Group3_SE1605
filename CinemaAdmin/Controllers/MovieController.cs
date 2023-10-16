using BusinessObject.Repository;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using X.PagedList;

namespace CinemaAdmin.Controllers
{
    [Authorize(Roles = "a")]

    public class MovieController : Controller
    {
        IMovieRepository movieRepository;
        public MovieController()
        {
            movieRepository = new MovieRepository();
        }
        public ActionResult Index(string SearchText, int? page)
        {
            var movies = movieRepository.GetMovie();
            var pageSize = 3;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(SearchText))
            {
                movies = movies.Where(c => c.MovieName.ToLower().Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            movies = movies.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            //ViewBag.Movies = movies.ToList().ToPagedList(pageSize, 1);
            return View(movies);
        }

        // GET: SeatsController/Details/5
        public ActionResult Details(int id)
        {
            var movie = movieRepository.GetMovieById(id);
            return View(movie);
        }

        // GET: SeatsController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: SeatsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                movieRepository.Insert(movie);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(movie);
            }
        }

        // GET: SeatsController/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: SeatsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                if (id != movie.MovieId)
                {
                    return NotFound();
                }

                movieRepository.Update(movie);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }


        public ActionResult Delete(Movie movie, int? id)
        {
            try
            {
                movie = movieRepository.GetMovieById(id.Value);
                if (movie != null)
                {
                    movieRepository.Delete(movie);
                    return RedirectToAction(nameof(Index));
                }
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}