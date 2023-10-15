using Library.Data;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly ApplicationDbContext _context;
        public IAuthorRepository Author { get; private set; }
        public IBookRepository Book { get; private set; }
        public IBookAuthorRepository BookAuthor { get; private set; }

        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            _context = context;

            Author = new AuthorRepository(_context);
            Book = new BookRepository(_context);
            BookAuthor = new BookAuthorRepository(_context);
        }

        public void Save() => _context.SaveChanges();

    }
}
