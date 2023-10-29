using Library.Configuration;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            try
            {
                var result = _unitOfWork.DepartmentService.GetAllDepartments();
                return View(result);
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
                var result = _unitOfWork.DepartmentService.GetDepartment(id);
                return View(result);
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
                var result = _unitOfWork.DepartmentService.GetDepartment(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(Department model)
        {
            try
            {
                _unitOfWork.DepartmentService.Update(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var result = _unitOfWork.DepartmentService.GetDepartment(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Delete(Department model)
        {
            try
            {
                _unitOfWork.DepartmentService.DeleteDepartment(model);
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
        public IActionResult Create(Department model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.DepartmentService.Add(model);
                    _unitOfWork.Save();
                }
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }


    }
}
