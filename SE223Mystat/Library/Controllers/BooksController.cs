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

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _unitOfWork.BookService.GetAllBooks();
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _unitOfWork.BookService.GetSingleBookWithAuthors(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _unitOfWork.BookService.GetSingleBookWithAuthors(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                BookWithManyAuthors bookWithManyAuthors = new();

                var book = await GetSingleBookWithAllAuthors();
                var author = await GetSingleBookWithAllAuthors();

                bookWithManyAuthors.Book = book.Book;
                bookWithManyAuthors.Authors = author.Authors;

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

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _unitOfWork.BookService.GetSingleBookWithAuthors(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(BookWithManyAuthors bookWithManyAuthors)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.BookAuthorService.UpdateAuthorsOfTheBook(bookWithManyAuthors.Book.Id, bookWithManyAuthors.SelectedAuthorIds);
                    await _unitOfWork.Save();

                    _unitOfWork.BookService.UpdateBook(bookWithManyAuthors);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookWithManyAuthors newBookModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.BookService.AddNewBook(newBookModel);
                    await _unitOfWork.Save();

                    await _unitOfWork.BookService.AddAuthorsOfTheBook(newBookModel, newBookModel.SelectedAuthorIds);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BookAuthor model)
        {
            try
            {
                await _unitOfWork.BookService.DeleteBook(model.Id);
                await _unitOfWork.Save();
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(Index));
        }




        private async Task<BookWithManyAuthors> GetSingleBookWithAllAuthors()
        {
            BookWithManyAuthors result = new();
            try
            {
                result.Book = new();

                result.Authors = await _unitOfWork.AuthorService
                    .GetAllAuthors();

                result.AuthorsOfTheBook = await _unitOfWork.BookAuthorService
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
