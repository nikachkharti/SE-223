using Library.Entities;
using Library.Models;

namespace Library.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(int id);
        Task DeleteEmployee(Employee model);
        Task Add(EmployeeWithManyDepartments model);
        void UpdateEmployee(EmployeeWithManyDepartments model);
    }
}
