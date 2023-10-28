using BusinessObject.Repository;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CinemaAdmin.Controllers
{
    public class SeatController : Controller
    {
        ISeatRepository seatRepository;
        public SeatController() => seatRepository = new SeatRepository();
        public ActionResult Index(int? page)
        {
            var seat = seatRepository.GetSeats();
            var pageSize = 3;
            if (page == null)
            {
                page = 1;
            }

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            seat = seat.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            //ViewBag.Movies = movies.ToList().ToPagedList(pageSize, 1);
            return View(seat);
        }

        public ActionResult Create()
        {
            ITheaterHallRepository theaterhall = new TheaterHallRepository();
            ViewData["TheaterHall"] = new SelectList(theaterhall.GetTheaterHalls(), "TheaterHallId", "TheaterHallName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seat seat)
        {
            ITheaterHallRepository theaterhall = new TheaterHallRepository();
            ViewData["TheaterHall"] = new SelectList(theaterhall.GetTheaterHalls(), "TheaterHallId", "TheaterHallName");
            try
            {
                seatRepository.InsertSeat(seat);
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
            ITheaterHallRepository theaterhall = new TheaterHallRepository();
            ViewData["TheaterHall"] = new SelectList(theaterhall.GetTheaterHalls(), "TheaterHallId", "TheaterHallName");
            if (id == null)
            {
                return NotFound();
            }
            var seat = seatRepository.GetSeatbyID(id.Value);
            if (theaterhall == null)
            {
                return NotFound();
            }
            return View(seat);
        }

        // POST: SeatsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Seat seat)
        {

            ITheaterHallRepository theaterhall = new TheaterHallRepository();
            ViewData["TheaterHall"] = new SelectList(theaterhall.GetTheaterHalls(), "TheaterHallId", "TheaterHallName");
            try
            {
                if (id != seat.SeatId)
                {
                    return NotFound();
                }

                seatRepository.UpdateSeat(seat);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(Seat seat, int? id)
        {
            try
            {
                seat = seatRepository.GetSeatbyID(id.Value);
                if (seat != null)
                {
                    seatRepository.DeleteSeat(seat.SeatId);
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
