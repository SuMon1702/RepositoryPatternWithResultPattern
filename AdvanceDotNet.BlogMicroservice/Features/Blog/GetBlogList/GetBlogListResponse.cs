using AdvanceDotNetBatch1.Database.Models;

namespace AdvanceDotNet.BlogMicroservice.Features.Blog.GetBlogList
{
    public record GetBlogListResponse(List<TblBlog> Blogs);
    
}
