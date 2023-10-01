using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var authors = _context.Authors;
            return View(authors);
        }

        public IActionResult Details(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            return View(author);
        }

        public IActionResult Edit(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Author model)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(model);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Delete(Author model)
        {
            _context.Authors.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
