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

        public async Task<IActionResult> Index()
        {
            try
            {
                var allAuthors = await _unitOfWork.AuthorService.GetAllAuthors();
                return View(allAuthors);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var singleAuthor = await _unitOfWork.AuthorService.GetAuthor(id);
                return View(singleAuthor);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var singleAuthor = await _unitOfWork.AuthorService.GetAuthor(id);
                return View(singleAuthor);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Author author)
        {
            try
            {
                _unitOfWork.AuthorService.Update(author);
                await _unitOfWork.Save();
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
        public async Task<IActionResult> Create(Author model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.AuthorService.Add(model);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var singleAuthor = await _unitOfWork.AuthorService.GetAuthor(id);
                return View(singleAuthor);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Author model)
        {
            try
            {
                await _unitOfWork.AuthorService.DeleteAuthor(model);
                await _unitOfWork.Save();
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }

    }
}
