using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthors();
        Task<Author> GetAuthor(int id);
        Task DeleteAuthor(Author model);
        Task Add(Author newAuthorModel);
        void Update(Author authorToUpdate);
    }
}
