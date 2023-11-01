using Library.Data;
using Library.Models;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Employee entity)
        {
            var employeeToUpdate = await _context.Employees.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = entity.FirstName;
                employeeToUpdate.LastName = entity.LastName;
                employeeToUpdate.Pin = entity.Pin;
                employeeToUpdate.Email = entity.Email;
                employeeToUpdate.PhoneNumber = entity.PhoneNumber;
                employeeToUpdate.DepartmentId = entity.DepartmentId;
            }
        }
    }
}
