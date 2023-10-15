using Library.Data;
using Library.Models;
using Library.Repository.Interfaces;

namespace Library.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Author entity)
        {
            var authorToUpdate = _context.Authors.FirstOrDefault(x => x.Id == entity.Id);

            if (authorToUpdate != null)
            {
                authorToUpdate.FirstName = entity.FirstName;
                authorToUpdate.LastName = entity.LastName;
                authorToUpdate.DateOfBirth = entity.DateOfBirth;
                authorToUpdate.DateOfDeath = entity.DateOfDeath;
                authorToUpdate.DateOfDeath = entity.DateOfDeath;
            }
        }
    }
}
