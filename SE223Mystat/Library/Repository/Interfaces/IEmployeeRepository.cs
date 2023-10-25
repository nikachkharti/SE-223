using Library.Models;

namespace Library.Repository.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>, IUpdateable<Employee>
    {
    }
}
