using AdvanceDotNetBatch1.Database.Models;

namespace AdvanceDotNet.BlogMicroservice.Features.Blog
{
    public class BlogRepository : RepositoryBase<TblBlog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
