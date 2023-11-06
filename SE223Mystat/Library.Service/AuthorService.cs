using Library.Entities;
using Library.Helper.Exceptions;
using Library.Repository;
using Library.Service.Interfaces;

namespace Library.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            var result = await _authorRepository.GetAll();

            if (result.Count() > 0)
            {
                return result.ToList();
            }
            else
            {
                throw new NoAuthorException();
            }
        }

        public async Task<Author> GetAuthor(int id)
        {
            var result = await _authorRepository.Get(author => author.Id == id);

            if (result is not null)
            {
                return result;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task DeleteAuthor(Author model)
        {
            var authorToDelete = await _authorRepository.Get(author => author.Id == model.Id);

            if (authorToDelete is not null)
            {
                _authorRepository.Remove(authorToDelete);
            }
            else
            {
                throw new NullReferenceException();
            }
        }


        public async Task Add(Author newAuthorModel)
        {
            var allAuthors = await _authorRepository.GetAll();

            bool authorAlreadyExists = allAuthors
                .Any(x => x.FirstName.Contains(newAuthorModel.FirstName, StringComparison.OrdinalIgnoreCase) && x.LastName.Contains(newAuthorModel.LastName, StringComparison.OrdinalIgnoreCase));


            if (!authorAlreadyExists)
            {
                await _authorRepository.Add(newAuthorModel);
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
