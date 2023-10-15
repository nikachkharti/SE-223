using Library.Data;
using Library.Models;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public class BookAuthorRepository : Repository<BookAuthor>, IBookAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public BookAuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(BookAuthor entity)
        {
            var dataToUpdate = _context.BookAuthor.FirstOrDefault(x => x.Id == entity.Id);
            if (dataToUpdate != null)
            {
                dataToUpdate.BookId = entity.BookId;
                dataToUpdate.AuthorId = entity.AuthorId;
            }
        }
    }
}
