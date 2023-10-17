using Library.Models.ViewModels;
using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        BookWithManyAuthors GetSingleBookWithAuthors(int bookId);
        void AddNewBook(BookWithManyAuthors newBook);
        void AddAuthorsOfTheBook(BookWithManyAuthors newBook, List<string> selectedAuthorIds);
        void DeleteBook(int id);
        void UpdateBook(BookWithManyAuthors model);
    }
}
