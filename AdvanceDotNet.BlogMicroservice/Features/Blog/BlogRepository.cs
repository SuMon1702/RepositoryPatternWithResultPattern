using AdvanceDotNetBatch1.Database.Models;

namespace AdvanceDotNet.BlogMicroservice.Features.Blog
{
    public class BlogRepository : RepositoryBase<TblBlog>, IBlogRepository
    {
        private AppDbContext context;

        public BlogRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}
