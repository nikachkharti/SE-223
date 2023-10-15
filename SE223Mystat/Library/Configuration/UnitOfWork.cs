using Library.Data;
using Library.Repository;
using Library.Repository.Interfaces;
using Library.Services;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IAuthorRepository Author { get; private set; }
        public IBookRepository Book { get; private set; }
        public IBookAuthorRepository BookAuthor { get; private set; }

        public IAuthorService AuthorService { get; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Author = new AuthorRepository(_context);
            Book = new BookRepository(_context);
            BookAuthor = new BookAuthorRepository(_context);


            AuthorService = new AuthorService(Author);
        }

        public void Save() => _context.SaveChanges();

    }
}
