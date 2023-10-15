using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author GetAuthor(int id);
        void DeleteAuthor(Author model);
        void Add(Author newAuthorModel);
        void Update(Author authorToUpdate);
    }
}
