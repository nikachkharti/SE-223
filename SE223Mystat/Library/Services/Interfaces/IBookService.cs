using Library.Models.ViewModels;
using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<BookWithManyAuthors> GetSingleBookWithAuthors(int bookId);
        Task AddNewBook(BookWithManyAuthors newBook);
        Task AddAuthorsOfTheBook(BookWithManyAuthors newBook, List<string> selectedAuthorIds);
        Task DeleteBook(int id);
        void UpdateBook(BookWithManyAuthors model);
    }
}
