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

        public async Task Add(T entity) => await _dbSet.AddAsync(entity);
        public void Remove(T entity) => _dbSet.Remove(entity);
        public void RemoveRange(IEnumerable<T> entites) => _dbSet.RemoveRange(entites);


        public async Task<IEnumerable<T>> GetAll(string? includeProperties = null)
        {
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                IQueryable<T> query = _dbSet;

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return await query.ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                IQueryable<T> query = _dbSet;

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return await query
                    .Where(filter)
                    .ToListAsync();
            }
            return await _dbSet
                .Where(filter)
                .ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                IQueryable<T> query = _dbSet;

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return await query
                    .Where(filter)
                    .FirstOrDefaultAsync();
            }

            return await _dbSet
                .Where(filter)
                .FirstOrDefaultAsync();
        }
    }
}
