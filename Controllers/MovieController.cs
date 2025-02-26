using Microsoft.AspNetCore.Mvc;
using TP2.Data;
using TP2.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TP2.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public IActionResult Create()
        {
            ViewData["IdGenre"] = new SelectList(_context.Genres, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Movie/Edit/{id}
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/{id}
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/DeleteConfirmed/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
