using Library.Models;

namespace Library.Repository.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>, IUpdateable<Department>
    {
    }
}
