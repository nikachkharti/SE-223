using Library.Data;
using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Department entity)
        {
            var departmentToUpdate = await _context.Departments.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (departmentToUpdate != null)
            {
                departmentToUpdate.Name = entity.Name;
                departmentToUpdate.Salary = entity.Salary;
            }
        }
    }
}
