using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IBookAuthorService
    {
        Task<List<Author>> GetAllBooksWithAuthors(int bookId);
        Task UpdateAuthorsOfTheBook(int bookId, List<string> authorIdsAsText);
    }
}
