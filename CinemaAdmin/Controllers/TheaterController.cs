using BusinessObject.Repository;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using X.PagedList;

namespace CinemaAdmin.Controllers
{
    [Authorize(Roles = "a")]
    public class TheaterController : Controller
    {
        ITheaterRepository theaterRepository;
        public TheaterController()
        {
            theaterRepository = new TheaterRepository();
        }

        public IActionResult Index(int? page, string SearchText)
        {
            var theater = theaterRepository.GetTheaters();
            var pageSize = 3;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(SearchText))
            {
                theater = theater.Where(c => c.TheaterName.Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            theater = theater.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            //ViewBag.Movies = movies.ToList().ToPagedList(pageSize, 1);
            return View(theater);
        }


        public ActionResult Create()
        {
  
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Theater theater)
        {
            try
            {
                theaterRepository.InsertTheater(theater);
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

            if (id == null)
            {
                return NotFound();
            }
            var theater = theaterRepository.GetTheaterById(id.Value);
            if (theater == null)
            {
                return NotFound();
            }
            return View(theater);
        }

        // POST: SeatsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Theater theater)
        {

            try
            {
                if (id != theater.TheaterId)
                {
                    return NotFound();
                }

                theaterRepository.UpdateTheater(theater);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
        public IActionResult Delete(Theater theater, int? id)
        {
            try
            {
                theater = theaterRepository.GetTheaterById(id.Value);
                if (theater != null)
                {
                    theaterRepository.DeleteTheater(theater.TheaterId);
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
