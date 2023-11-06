using Library.Repository;

namespace Library.Service.Interfaces
{
    public interface IUnitOfWork
    {
        Task Save();

        public IAuthorRepository Author { get; }
        public IBookRepository Book { get; }
        public IBookAuthorRepository BookAuthor { get; }
        public IDepartmentRepository Department { get; }
        public IEmployeeRepository Employee { get; }

        public IAuthorService AuthorService { get; }
        public IBookService BookService { get; }
        public IBookAuthorService BookAuthorService { get; }
        public IDepartmentService DepartmentService { get; }
        public IEmployeeService EmployeeService { get; }
    }
}
