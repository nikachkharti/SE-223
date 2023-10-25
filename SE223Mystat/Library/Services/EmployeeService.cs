using Library.Models;
using Library.Models.ViewModels;
using Library.Repository;
using Library.Repository.Interfaces;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Add(EmployeeWithManyDepartments model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            _employeeRepository.Add(model.Employee);
        }

        public void DeleteEmployee(Employee model)
        {
            var result = _employeeRepository.Get(author => author.Id == model.Id);

            if (result is not null)
            {
                _employeeRepository.Remove(result);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var result = _employeeRepository
                .GetAll(includeProperties: "Department")
                .ToList();

            if (result.Count() > 0)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public Employee GetEmployee(int id)
        {
            var result = _employeeRepository
                .Get(author => author.Id == id, "Department");

            if (result is not null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void UpdateEmployee(EmployeeWithManyDepartments model)
        {
            if (model is not null)
            {
                _employeeRepository.Update(model.Employee);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
