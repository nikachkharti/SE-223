namespace Library.Repository.Interfaces
{
    public interface IUpdateable<T> where T : class
    {
        void Update(T entity);
    }
}
