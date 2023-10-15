namespace Library.Repository.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        public IAuthorRepository Author { get; }
        public IBookRepository Book { get; }
        public IBookAuthorRepository BookAuthor { get; }
    }
}
