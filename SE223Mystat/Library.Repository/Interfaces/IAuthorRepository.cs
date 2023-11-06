using Library.Entities;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public interface IAuthorRepository : IRepository<Author>, IUpdateable<Author>
    {
    }
}
