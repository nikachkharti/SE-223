using Library.Data;
using Library.Models;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Book entity)
        {
            var bookToUpdate = await _context.Books.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = entity.Title;
                bookToUpdate.Description = entity.Description;
                bookToUpdate.Quantity = entity.Quantity;
            }
        }
    }
}
