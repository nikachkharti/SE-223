using Library.Models;

namespace Library.Repository.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>, IUpdateable<Author>
    {
    }
}
