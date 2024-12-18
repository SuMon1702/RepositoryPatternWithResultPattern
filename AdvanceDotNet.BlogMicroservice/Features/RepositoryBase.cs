using AdvanceDotNetBatch1.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdvanceDotNet.BlogMicroservice.Features
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        internal readonly AppDbContext _context;
        internal readonly DbSet<T> _dbSet;

        public RepositoryBase (AppDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public void Add(T entity)
        {
           
        }

        public Task AddAsync(T entity, CancellationToken cs = default)
        {
            throw new NotImplementedException();
        }

        public void AddRange(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cs = default)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
