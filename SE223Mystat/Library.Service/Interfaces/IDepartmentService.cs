using Library.Entities;

namespace Library.Service.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartment(int id);
        Task DeleteDepartment(Department model);
        Task Add(Department model);
        void Update(Department model);
    }
}
