using AutoMapper.Configuration;
using Library.Entities;
using Library.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

        public AuthorsController(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
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
        public async Task<IActionResult> Create(Author model, IFormFile? file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var wwwroot = _environment.WebRootPath;

                    if (file != null)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string filePath = Path.Combine(wwwroot, @"img\");
                        string directoryPath = Path.GetDirectoryName(Path.Combine(filePath, fileName));

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        using (FileStream fileStream = new(Path.Combine(filePath, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        model.ImageUrl = fileName;
                    }

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
