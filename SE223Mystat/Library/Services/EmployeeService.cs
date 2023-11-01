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

        public async Task Add(EmployeeWithManyDepartments model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            await _employeeRepository.Add(model.Employee);
        }

        public async Task DeleteEmployee(Employee model)
        {
            var result = await _employeeRepository.Get(author => author.Id == model.Id);

            if (result is not null)
            {
                _employeeRepository.Remove(result);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var result = await _employeeRepository
                .GetAll(includeProperties: "Department");

            if (result.Count() > 0)
            {
                return result.ToList();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var result = await _employeeRepository
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
