using Library.Data;
using Library.Repository;
using Library.Repository.Interfaces;
using Library.Services;
using Library.Services.Interfaces;

namespace Library.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IAuthorRepository Author { get; private set; }
        public IBookRepository Book { get; private set; }
        public IBookAuthorRepository BookAuthor { get; private set; }

        public IAuthorService AuthorService { get; private set; }
        public IBookService BookService { get; private set; }
        public IBookAuthorService BookAuthorService { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Author = new AuthorRepository(_context);
            Book = new BookRepository(_context);
            BookAuthor = new BookAuthorRepository(_context);


            AuthorService = new AuthorService(Author);
            BookService = new BookService(Book, BookAuthor, Author);
            BookAuthorService = new BookAuthorService(BookAuthor, Author);
        }

        public void Save() => _context.SaveChanges();

    }
}
