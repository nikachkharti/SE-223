using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IBookAuthorService
    {
        List<Author> GetAllBooksWithAuthors(int bookId);
        void UpdateAuthorsOfTheBook(int bookId, List<string> authorIdsAsText);
    }
}
