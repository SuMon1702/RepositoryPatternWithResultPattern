using AdvanceDotNetBatch1.Database.Models;

namespace SMDotNet.GenericRepositoryPattern.Persistance.Repositories
{
    public class BlogRepository : RepositoryBase<TblBlog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
