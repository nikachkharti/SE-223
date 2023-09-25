using Microsoft.AspNetCore.Mvc;
using Mystat.Models;
using MystatService;
using MystatService.Interfaces;

namespace Mystat.Presentation.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentsController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IActionResult> Index()
        {
            List<Student> students = await _unitOfWork.Student.GetAllStudentsAsync();
            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {
            Student student = await _unitOfWork.Student.GetStudentByIdAsync(id);
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            await _unitOfWork.Student.AddNewStudentAsync(model);
            return RedirectToAction("Index");
        }

        //ახალი სტუდენტის ჩამატება
        //UPDATE
        //DELETE

    }
}
