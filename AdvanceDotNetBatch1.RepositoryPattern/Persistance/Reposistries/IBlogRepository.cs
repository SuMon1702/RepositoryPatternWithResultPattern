using AdvanceDotNetBatch1.RepositoryPattern.Models;
using AdvanceDotNetBatch1.Utlis;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AdvanceDotNetBatch1.RepositoryPattern.Persistance.Reposistries
{
    public interface IBlogRepository
    {
        Task<Result<List<BlogModel>>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs);
    }
}
