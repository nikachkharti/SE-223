using Library.Entities;
using Library.Models;
using Library.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _unitOfWork.EmployeeService.GetAllEmployees();
                return View(result);
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
                var result = await _unitOfWork.EmployeeService.GetEmployee(id);
                return View(result);
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
                EmployeeWithManyDepartments employeeWithManyDepartments = new();
                employeeWithManyDepartments.Employee = await _unitOfWork.EmployeeService.GetEmployee(id);
                var allDepartments = await _unitOfWork.DepartmentService.GetAllDepartments();
                employeeWithManyDepartments.Departments = allDepartments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

                return View(employeeWithManyDepartments);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeWithManyDepartments model)
        {
            try
            {
                _unitOfWork.EmployeeService.UpdateEmployee(model);
                await _unitOfWork.Save();
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
                var result = await _unitOfWork.EmployeeService.GetEmployee(id);
                return View(result);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Employee model)
        {
            try
            {
                await _unitOfWork.EmployeeService.DeleteEmployee(model);
                await _unitOfWork.Save();
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            EmployeeWithManyDepartments employeeWithManyDepartments = new();
            employeeWithManyDepartments.Employee = new();
            var allDepartments = await _unitOfWork.DepartmentService.GetAllDepartments();
            employeeWithManyDepartments.Departments = allDepartments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            return View(employeeWithManyDepartments);
        }


        [HttpPost]
        public async Task<IActionResult> Create(EmployeeWithManyDepartments model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.EmployeeService.Add(model);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Index");
        }


    }
}
