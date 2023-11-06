using Library.Entities;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public interface IBookRepository : IRepository<Book>, IUpdateable<Book>
    {
    }
}
