using Library.Entities;

namespace Library.Service.Interfaces
{
    public interface IBookAuthorService
    {
        Task<List<Author>> GetAllBooksWithAuthors(int bookId);
        Task UpdateAuthorsOfTheBook(int bookId, List<string> authorIdsAsText);
    }
}
