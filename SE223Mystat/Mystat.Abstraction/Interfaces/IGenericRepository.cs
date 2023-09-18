namespace Mystat.Abstraction.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<List<T>> GETAllAsyncProcedure(string procedure, params object[] parameters);
        Task<List<T>> GETAllAsyncQuery(string query);
        Task<T> GETAsyncProcedure(string procedure, params object[] parameters);
        Task<T> GETAsyncQuery(string query);
        Task POSTAsyncProcedure(string procedure, params object[] parameters);
        Task POSTAsyncQuery(string query);
    }
}
