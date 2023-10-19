using BusinessObject.Repository;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using X.PagedList;

namespace CinemaAdmin.Controllers
{
    [Authorize(Roles = "a")]
    public class MovieShowController : Controller
    {
        IMovieShowRepository movieShowRepository;
        public MovieShowController() => movieShowRepository = new MovieShowRepository();
        public ActionResult Index(int? page, string SearchText)
        {
            var movieShow = movieShowRepository.GetMovieShows();
            var pageSize = 3;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(SearchText))
            {
                movieShow = movieShow.Where(c => c.ShowTime.Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            movieShow = movieShow.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            //ViewBag.Movies = movies.ToList().ToPagedList(pageSize, 1);
            return View(movieShow);
        }

        public ActionResult Create()
        {
            IMovieRepository movie = new MovieRepository();
            ViewData["Movie"] = new SelectList(movie.GetMovie(), "MovieId", "MovieName");
            ITheaterHallRepository theaterHall = new TheaterHallRepository();
            ViewData["TheaterHall"] = new SelectList(theaterHall.GetTheaterHalls(), "TheaterHallId", "TheaterHallName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieShow movieShow)
        {
            IMovieRepository movie = new MovieRepository();
            ViewData["Movie"] = new SelectList(movie.GetMovie(), "MovieId", "MovieName");
            ITheaterHallRepository theaterHall = new TheaterHallRepository();
            ViewData["TheaterHall"] = new SelectList(theaterHall.GetTheaterHalls(), "TheaterHallId", "TheaterHallName");
            try
            {
                movieShowRepository.Insert(movieShow);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            IMovieRepository movie = new MovieRepository();
            ViewData["Movie"] = new SelectList(movie.GetMovie(), "MovieId", "MovieName");
            ITheaterHallRepository theaterHall = new TheaterHallRepository();
            ViewData["TheaterHall"] = new SelectList(theaterHall.GetTheaterHalls(), "TheaterHallId", "TheaterHallName");
            if (id == null)
            {
                return NotFound();
            }
            var movieShow = movieShowRepository.GetMovieShowsById(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movieShow);
        }

        // POST: SeatsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieShow movieShow)
        {
            IMovieRepository movie = new MovieRepository();
            ViewData["Movie"] = new SelectList(movie.GetMovie(), "MovieId", "MovieName");
            ITheaterHallRepository theaterHall = new TheaterHallRepository();
            ViewData["TheaterHall"] = new SelectList(theaterHall.GetTheaterHalls(), "TheaterHallId", "TheaterHallName");
            try
            {
                if (id != movieShow.MovieShowId)
                {
                    return NotFound();
                }

                movieShowRepository.Update(movieShow);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }


        public ActionResult Delete(MovieShow movieShow, int? id)
        {
            try
            {
                movieShow = movieShowRepository.GetMovieShowsById(id.Value);
                if (movieShow != null)
                {
                    movieShowRepository.Delete(movieShow.MovieShowId);
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

