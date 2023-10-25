using Library.Models;
using Library.Repository.Interfaces;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            _departmentRepository.Add(model);
        }

        public void DeleteDepartment(Department model)
        {
            var result = _departmentRepository.Get(author => author.Id == model.Id);

            if (result is not null)
            {
                _departmentRepository.Remove(result);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Department> GetAllDepartments()
        {
            var result = _departmentRepository.GetAll().ToList();

            if (result.Count() > 0)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public Department GetDepartment(int id)
        {
            var result = _departmentRepository.Get(author => author.Id == id);

            if (result is not null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Department model)
        {
            if (model is not null)
            {
                _departmentRepository.Update(model);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
