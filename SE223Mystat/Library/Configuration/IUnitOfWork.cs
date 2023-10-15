using Library.Repository.Interfaces;
using Library.Services.Interfaces;

namespace Library.Configuration
{
    public interface IUnitOfWork
    {
        void Save();

        public IAuthorRepository Author { get; }
        public IBookRepository Book { get; }
        public IBookAuthorRepository BookAuthor { get; }

        public IAuthorService AuthorService { get; }
    }
}
