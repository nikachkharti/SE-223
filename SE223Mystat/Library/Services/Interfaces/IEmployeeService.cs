using Library.Models;
using Library.Models.ViewModels;

namespace Library.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        void DeleteEmployee(Employee model);
        void Add(EmployeeWithManyDepartments model);
        void UpdateEmployee(EmployeeWithManyDepartments model);
    }
}
