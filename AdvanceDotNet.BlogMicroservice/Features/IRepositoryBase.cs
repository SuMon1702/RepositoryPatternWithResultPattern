using System.Linq.Expressions;

namespace AdvanceDotNet.BlogMicroservice.Features
{
    public interface IRepositoryBase<T> where T : class

    {
        IQueryable<T> Query(Expression<Func<T, bool>> expression);

        IEnumerable<T>GetAll();
        Task AddAsync(T entity, CancellationToken cs= default);
        void Add(T entity);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cs= default);
        void AddRange(T entity);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken);


    }
}
