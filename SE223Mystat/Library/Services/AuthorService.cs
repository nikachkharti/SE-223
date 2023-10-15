using Library.Exceptions.Authors;
using Library.Models;
using Library.Repository.Interfaces;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<Author> GetAllAuthors()
        {
            var result = _authorRepository.GetAll().ToList();

            if (result.Count() > 0)
            {
                return result;
            }
            else
            {
                throw new NoAuthorException();
            }
        }

        public Author GetAuthor(int id)
        {
            var result = _authorRepository.Get(author => author.Id == id);

            if (result is not null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void DeleteAuthor(Author model)
        {
            var authorToDelete = _authorRepository.Get(author => author.Id == model.Id);

            if (authorToDelete is not null)
            {
                _authorRepository.Remove(authorToDelete);
            }
            else
            {
                throw new NullReferenceException();
            }
        }


        public void Add(Author newAuthorModel)
        {
            bool authorAlreadyExists = _authorRepository
                .GetAll()
                .Any(x => x.FirstName.Contains(newAuthorModel.FirstName, StringComparison.OrdinalIgnoreCase) && x.LastName.Contains(newAuthorModel.LastName, StringComparison.OrdinalIgnoreCase));

            if (!authorAlreadyExists)
            {
                _authorRepository.Add(newAuthorModel);
            }
            else
            {
                throw new AuthorAlreadyExistsException();
            }
        }


        public void Update(Author authorToUpdate)
        {
            if (authorToUpdate is not null)
            {
                _authorRepository.Update(authorToUpdate);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

    }
}
