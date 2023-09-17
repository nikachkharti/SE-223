using Mystat.Abstraction.Interfaces;

namespace Mystat.Abstraction
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        public Task<List<T>> GETAllAsync(string procedure, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GETAllAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<T> GETAsync(string procedure, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<T> GETAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task POSTAsync(string procedure, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task POSTAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
