using Library.Configuration;
using Library.Models;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            try
            {
                var result = _unitOfWork.EmployeeService.GetAllEmployees();
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
                var result = _unitOfWork.EmployeeService.GetEmployee(id);
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
                EmployeeWithManyDepartments employeeWithManyDepartments = new()
                {
                    Employee = _unitOfWork.EmployeeService.GetEmployee(id),
                    Departments = _unitOfWork.DepartmentService.GetAllDepartments().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                };

                return View(employeeWithManyDepartments);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeWithManyDepartments model)
        {
            try
            {
                _unitOfWork.EmployeeService.UpdateEmployee(model);
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
                var result = _unitOfWork.EmployeeService.GetEmployee(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Delete(Employee model)
        {
            try
            {
                _unitOfWork.EmployeeService.DeleteEmployee(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            EmployeeWithManyDepartments employeeWithManyDepartments = new()
            {
                Employee = new(),
                Departments = _unitOfWork.DepartmentService.GetAllDepartments().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            };

            return View(employeeWithManyDepartments);
        }


        [HttpPost]
        public IActionResult Create(EmployeeWithManyDepartments model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.EmployeeService.Add(model);
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
