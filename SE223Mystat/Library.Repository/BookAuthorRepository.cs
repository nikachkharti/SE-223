using Library.Data;
using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class BookAuthorRepository : Repository<BookAuthor>, IBookAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public BookAuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(BookAuthor entity)
        {
            var dataToUpdate = await _context.BookAuthor.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (dataToUpdate != null)
            {
                dataToUpdate.BookId = entity.BookId;
                dataToUpdate.AuthorId = entity.AuthorId;
            }
        }
    }
}
