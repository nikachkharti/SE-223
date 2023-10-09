using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Books.ToList();
            return View(result);
        }

        public IActionResult Details(int id)
        {
            var result = _context.Books.FirstOrDefault(x => x.Id == id);
            return View(result);
        }

        public IActionResult Edit(int id)
        {
            var result = _context.Books.FirstOrDefault(x => x.Id == id);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            return View(book);
        }


        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _context.Books.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
