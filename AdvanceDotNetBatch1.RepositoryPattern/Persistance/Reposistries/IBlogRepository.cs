using AdvanceDotNet.RepositoryPattern.Models;
using AdvanceDotNet.Utlis;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AdvanceDotNet.RepositoryPattern.Persistance.Reposistries
{
    public interface IBlogRepository
    {
        Task<Result<List<BlogModel>>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs);
        Task<Result<List<BlogRequestModel>>> CreateBlogListAsync(BlogRequestModel model, CancellationToken cs);

        Task<Result<BlogRequestModel>> UpdateBlogAsync(int blogId, BlogRequestModel model, CancellationToken cs);
        Task<Result<BlogModel>> DeleteBlogAsync(int blogId, CancellationToken cs);

    }
}
