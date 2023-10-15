using Library.Models;

namespace Library.Repository.Interfaces
{
    public interface IBookAuthorRepository : IRepository<BookAuthor>, IUpdateable<BookAuthor>
    {
    }
}
