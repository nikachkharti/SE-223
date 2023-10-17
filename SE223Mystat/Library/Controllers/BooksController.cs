using Library.Configuration;
using Library.Data;
using Library.Models;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            try
            {
                var result = _unitOfWork.BookService.GetAllBooks();
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                var result = _unitOfWork.BookService.GetSingleBookWithAuthors(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var result = _unitOfWork.BookService.GetSingleBookWithAuthors(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Create()
        {
            try
            {
                BookWithManyAuthors bookWithManyAuthors = new();
                bookWithManyAuthors.Book = GetSingleBookWithAllAuthors().Book;
                bookWithManyAuthors.Authors = GetSingleBookWithAllAuthors().Authors;

                return View(bookWithManyAuthors);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }


            //ძველი კოდი არ წავშალე სპეციალურად თუ დაგჭირდებათ ჩმოსაშლელი მენიუს გამოყენება ეწყობა ესე.
            //bookWithManyAuthors.AuthorsSelectList = bookWithManyAuthors.Authors.Select(x => new SelectListItem()
            //{
            //    Text = $"{x.FirstName} {x.LastName}",
            //    Value = x.Id.ToString()
            //});
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var result = _unitOfWork.BookService.GetSingleBookWithAuthors(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        public IActionResult Edit(BookWithManyAuthors bookWithManyAuthors)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.BookAuthorService.UpdateAuthorsOfTheBook(bookWithManyAuthors.Book.Id, bookWithManyAuthors.SelectedAuthorIds);
                    _unitOfWork.Save();

                    _unitOfWork.BookService.UpdateBook(bookWithManyAuthors);
                    _unitOfWork.Save();
                }
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(BookWithManyAuthors newBookModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.BookService.AddNewBook(newBookModel);
                    _unitOfWork.Save();

                    _unitOfWork.BookService.AddAuthorsOfTheBook(newBookModel, newBookModel.SelectedAuthorIds);
                    _unitOfWork.Save();
                }
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(BookAuthor model)
        {
            try
            {
                _unitOfWork.BookService.DeleteBook(model.Id);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(Index));
        }




        private BookWithManyAuthors GetSingleBookWithAllAuthors()
        {
            BookWithManyAuthors result = new();
            try
            {
                result.Book = new();

                result.Authors = _unitOfWork.AuthorService
                    .GetAllAuthors()
                    .ToList();

                result.AuthorsOfTheBook = _unitOfWork.BookAuthorService
                    .GetAllBooksWithAuthors(result.Book.Id);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

    }
}
