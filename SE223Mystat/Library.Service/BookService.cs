using Library.Entities;
using Library.Models;
using Library.Repository;
using Library.Service.Interfaces;

namespace Library.Service
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

        public async Task AddAuthorsOfTheBook(BookWithManyAuthors newBook, List<string> selectedAuthorIds)
        {
            foreach (var selectedAuthorIdAsText in selectedAuthorIds)
            {
                int.TryParse(selectedAuthorIdAsText, out int authorId);

                var author = await _authorRepository.GetAll(x => x.Id == authorId);

                if (author != null)
                {
                    await _bookAuthorRepository.Add(new BookAuthor
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

        public async Task AddNewBook(BookWithManyAuthors newBook)
        {
            await _bookRepository.Add(newBook.Book);
        }

        public async Task DeleteBook(int id)
        {
            var bookToDelete = await _bookRepository.Get(x => x.Id == id);
            _bookRepository.Remove(bookToDelete);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var allBooks = await _bookRepository.GetAll();
            return allBooks.ToList();
        }

        public async Task<BookWithManyAuthors> GetSingleBookWithAuthors(int bookId)
        {
            BookWithManyAuthors result = new();

            result.Book = await _bookRepository.Get(x => x.Id == bookId);

            var x = await _bookAuthorRepository
                .GetAll(filter: x => x.BookId == bookId, includeProperties: "Author");

            result.AuthorsOfTheBook = x
                .Select(x => x.Author)
                .ToList();


            var y = await _authorRepository
                .GetAll();

            result.Authors = y.ToList();

            return result;
        }

        public void UpdateBook(BookWithManyAuthors model)
        {
            _bookRepository.Update(model.Book);
        }
    }
}
