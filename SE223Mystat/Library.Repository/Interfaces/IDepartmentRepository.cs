using Library.Entities;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public interface IDepartmentRepository : IRepository<Department>, IUpdateable<Department>
    {
    }
}
