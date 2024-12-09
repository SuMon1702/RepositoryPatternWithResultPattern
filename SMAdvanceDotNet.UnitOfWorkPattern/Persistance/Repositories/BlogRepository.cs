using AdvanceDotNetBatch1.Database.Models;

namespace SMAdvanceDotNet.UnitOfWorkPattern.Persistance.Repositories
{
    public class BlogRepository : RepositoryBase<TblBlog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
