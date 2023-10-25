using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department GetDepartment(int id);
        void DeleteDepartment(Department model);
        void Add(Department model);
        void Update(Department model);
    }
}
