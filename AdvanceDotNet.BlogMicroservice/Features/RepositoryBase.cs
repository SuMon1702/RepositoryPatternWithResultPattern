using AdvanceDotNetBatch1.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdvanceDotNet.BlogMicroservice.Features
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        internal readonly AppDbContext _context;
        internal readonly DbSet<T> _dbSet;
        private AppDbContext context;

        public RepositoryBase(AppDbContext context)
        {
            this.context = context;
        }

        public RepositoryBase(AppDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(T entity, CancellationToken cs = default)
        {
            await _dbSet.AddAsync(entity, cs);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cs = default)
        {
            await _dbSet.AddRangeAsync(entities, cs);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
           _dbSet.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            return expression is not null? _dbSet.AsQueryable() : _dbSet.Where(expression);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync(CancellationToken cs= default)
        {
            await _context.SaveChangesAsync(cs);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
           _dbSet.UpdateRange(entities);
        }
    }
}
