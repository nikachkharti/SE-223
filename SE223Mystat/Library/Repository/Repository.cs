using Library.Data;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);
        public void Remove(T entity) => _dbSet.Remove(entity);
        public void RemoveRange(IEnumerable<T> entites) => _dbSet.RemoveRange(entites);
        public IEnumerable<T> GetAll() => _dbSet.ToList();
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter) => _dbSet.Where(filter).ToList();
        public T Get(Expression<Func<T, bool>> filter) => _dbSet.Where(filter).FirstOrDefault();

    }
}
