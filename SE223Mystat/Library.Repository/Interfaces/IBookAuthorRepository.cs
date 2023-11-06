using Library.Entities;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public interface IBookAuthorRepository : IRepository<BookAuthor>, IUpdateable<BookAuthor>
    {
    }
}
