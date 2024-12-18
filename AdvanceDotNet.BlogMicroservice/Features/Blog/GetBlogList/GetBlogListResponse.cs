using AdvanceDotNet.Database.Models;

namespace AdvanceDotNet.BlogMicroservice.Features.Blog.GetBlogList
{
    public record GetBlogListResponse(List<TblBlog> Blogs);
    
}
