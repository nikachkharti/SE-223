using Library.Entities;

namespace Library.Service.Interfaces
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
