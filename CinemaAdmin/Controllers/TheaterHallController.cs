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
    public class TheaterHallController : Controller
    {
        ITheaterHallRepository theaterHallRepository;

        public TheaterHallController()
        {
            theaterHallRepository = new TheaterHallRepository();
        }


        public IActionResult Index(int? page, string SearchText)
        {
            var theaterHall = theaterHallRepository.GetTheaterHalls();
            var pageSize = 3;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(SearchText))
            {
                theaterHall = theaterHall.Where(c => c.TheaterHallName.Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            theaterHall = theaterHall.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            //ViewBag.Movies = movies.ToList().ToPagedList(pageSize, 1);
            return View(theaterHall);
        }

        public ActionResult Create()
        {
            ITheaterRepository theater = new TheaterRepository();
            ViewData["Theater"] = new SelectList(theater.GetTheaters(), "TheaterId", "TheaterName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TheaterHall theaterHall)
        {
            ITheaterRepository theater = new TheaterRepository();
            ViewData["Theater"] = new SelectList(theater.GetTheaters(), "TheaterId", "TheaterName");
            try
            {
                theaterHallRepository.Insert(theaterHall);
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
            ITheaterRepository theater = new TheaterRepository();
            ViewData["Theater"] = new SelectList(theater.GetTheaters(), "TheaterId", "TheaterName");
            if (id == null)
            {
                return NotFound();
            }
            var theaterHall = theaterHallRepository.GetTheaterHallById(id.Value);
            if (theater == null)
            {
                return NotFound();
            }
            return View(theaterHall);
        }

        // POST: SeatsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TheaterHall theaterHall)
        {
            ITheaterRepository theater = new TheaterRepository();
            ViewData["Theater"] = new SelectList(theater.GetTheaters(), "TheaterId", "TheaterName");
            try
            {
                if (id != theaterHall.TheaterHallId)
                {
                    return NotFound();
                }

                theaterHallRepository.Update(theaterHall);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public IActionResult Delete(TheaterHall theaterHall, int? id)
        {
            try
            {
                theaterHall = theaterHallRepository.GetTheaterHallById(id.Value);
                if (theaterHall != null)
                {
                    theaterHallRepository.Delete(theaterHall.TheaterHallId);
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
