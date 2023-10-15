using Library.Models;

namespace Library.Repository.Interfaces
{
    public interface IBookRepository : IRepository<Book>, IUpdateable<Book>
    {
    }
}
