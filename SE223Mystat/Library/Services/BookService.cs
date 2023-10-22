using Library.Models;
using Library.Models.ViewModels;
using Library.Repository.Interfaces;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookService(IBookRepository bookRepository, IBookAuthorRepository bookAuthorRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _bookAuthorRepository = bookAuthorRepository;
            _authorRepository = authorRepository;
        }

        public void AddAuthorsOfTheBook(BookWithManyAuthors newBook, List<string> selectedAuthorIds)
        {
            foreach (var selectedAuthorIdAsText in selectedAuthorIds)
            {
                int.TryParse(selectedAuthorIdAsText, out int authorId);

                var author = _authorRepository.GetAll(x => x.Id == authorId).ToList();

                if (author != null)
                {
                    _bookAuthorRepository.Add(new BookAuthor
                    {
                        BookId = newBook.Book.Id,
                        AuthorId = authorId
                    });
                }
                else
                {
                    throw new NullReferenceException("Author object is null");
                }
            }
        }

        public void AddNewBook(BookWithManyAuthors newBook)
        {
            _bookRepository.Add(newBook.Book);
        }

        public void DeleteBook(int id)
        {
            var bookToDelete = _bookRepository.Get(x => x.Id == id);
            _bookRepository.Remove(bookToDelete);
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _bookRepository.GetAll();
            return allBooks.ToList();
        }

        public BookWithManyAuthors GetSingleBookWithAuthors(int bookId)
        {
            BookWithManyAuthors result = new();

            result.Book = _bookRepository.Get(x => x.Id == bookId);

            result.AuthorsOfTheBook = _bookAuthorRepository
                .GetAll(filter: x => x.BookId == bookId, includeProperties: "Author")
                .Select(x => x.Author)
                .ToList();

            result.Authors = _authorRepository
                .GetAll()
                .ToList();

            return result;
        }

        public void UpdateBook(BookWithManyAuthors model)
        {
            _bookRepository.Update(model.Book);
        }
    }
}
