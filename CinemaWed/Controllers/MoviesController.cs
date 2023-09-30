using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CinemaWed.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CinemaDbContext _cinemaDbContext;
        public MoviesController(CinemaDbContext cinemaDbContext)
        {
            _cinemaDbContext = cinemaDbContext;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _cinemaDbContext.Movies.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _cinemaDbContext.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,MovieName,Description,Price,Image")] Movie movie)
        {
            
                if (_cinemaDbContext.Movies.SingleOrDefault(m => m.MovieId == movie.MovieId) == null)
                {
                    _cinemaDbContext.Add(movie);
                    await _cinemaDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
         
            return View(movie);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _cinemaDbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieName,Description,Price,Image")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    _cinemaDbContext.Update(movie);
                    await _cinemaDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                return RedirectToAction(nameof(Index));

            }


            return View(movie);
        }


        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _cinemaDbContext.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Members/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _cinemaDbContext.Movies.FindAsync(id);
            _cinemaDbContext.Movies.Remove(movie);
            await _cinemaDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        
    }
}
