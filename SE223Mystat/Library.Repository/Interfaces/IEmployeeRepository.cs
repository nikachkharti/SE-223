using Library.Entities;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>, IUpdateable<Employee>
    {
    }
}
