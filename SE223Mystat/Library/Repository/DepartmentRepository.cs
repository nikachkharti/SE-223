using Library.Data;
using Library.Models;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Department entity)
        {
            var departmentToUpdate = _context.Departments.FirstOrDefault(x => x.Id == entity.Id);

            if (departmentToUpdate != null)
            {
                departmentToUpdate.Name = entity.Name;
                departmentToUpdate.Salary = entity.Salary;
            }
        }
    }
}
