using Library.Configuration;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            try
            {
                var allAuthors = _unitOfWork.AuthorService.GetAllAuthors();
                return View(allAuthors);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                var singleAuthor = _unitOfWork.AuthorService.GetAuthor(id);
                return View(singleAuthor);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var singleAuthor = _unitOfWork.AuthorService.GetAuthor(id);
                return View(singleAuthor);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            try
            {
                _unitOfWork.AuthorService.Update(author);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
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
            return View();
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var singleAuthor = _unitOfWork.AuthorService.GetAuthor(id);
                return View(singleAuthor);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(Author model)
        {
            try
            {
                _unitOfWork.AuthorService.DeleteAuthor(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }

    }
}
