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
            BookWithManyAuthors bookWithManyAuthors = new();
            bookWithManyAuthors.Book = new();
            bookWithManyAuthors.Authors = _context.Authors.ToList();

            //ძველი კოდი არ წავშალე სპეციალურად თუ დაგჭირდებათ ჩმოსაშლელი მენიუს გამოყენება ეწყობა ესე.
            //bookWithManyAuthors.AuthorsSelectList = bookWithManyAuthors.Authors.Select(x => new SelectListItem()
            //{
            //    Text = $"{x.FirstName} {x.LastName}",
            //    Value = x.Id.ToString()
            //});

            return View(bookWithManyAuthors);
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
        public IActionResult Create(BookWithManyAuthors newBookModel)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(newBookModel.Book);
                _context.SaveChanges();

                foreach (var selectedAuthorIdAsText in newBookModel.SelectedAuthors)
                {
                    int.TryParse(selectedAuthorIdAsText, out int selectedAuthorID);

                    var author = _context.Authors.Find(selectedAuthorID);

                    if (author != null)
                    {
                        _context.BookAuthor.Add(new BookAuthor
                        {
                            BookId = newBookModel.Book.Id,
                            AuthorId = selectedAuthorID
                        });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

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
