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
        public IDepartmentRepository Department { get; private set; }
        public IEmployeeRepository Employee { get; private set; }

        public IAuthorService AuthorService { get; private set; }
        public IBookService BookService { get; private set; }
        public IBookAuthorService BookAuthorService { get; private set; }
        public IDepartmentService DepartmentService { get; private set; }
        public IEmployeeService EmployeeService { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Author = new AuthorRepository(_context);
            Book = new BookRepository(_context);
            BookAuthor = new BookAuthorRepository(_context);
            Department = new DepartmentRepository(_context);
            Employee = new EmployeeRepository(_context);

            AuthorService = new AuthorService(Author);
            BookService = new BookService(Book, BookAuthor, Author);
            BookAuthorService = new BookAuthorService(BookAuthor, Author);
            DepartmentService = new DepartmentService(Department);
            EmployeeService = new EmployeeService(Employee);
        }

        public async Task Save() => await _context.SaveChangesAsync();

    }
}
