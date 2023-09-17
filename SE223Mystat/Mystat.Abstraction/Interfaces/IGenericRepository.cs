namespace Mystat.Abstraction.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<List<T>> GETAllAsync(string procedure, params object[] parameters);
        Task<List<T>> GETAllAsync(string query);
        Task<T> GETAsync(string procedure, params object[] parameters);
        Task<T> GETAsync(string query);
        Task POSTAsync(string procedure, params object[] parameters);
        Task POSTAsync(string query);
    }
}
