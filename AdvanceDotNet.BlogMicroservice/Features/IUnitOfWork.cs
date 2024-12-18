using AdvanceDotNet.BlogMicroservice.Features.Blog;

namespace AdvanceDotNet.BlogMicroservice.Features
{
    public interface IUnitOfWork
    {
        IBlogRepository BlogRepository { get; }
    }
}
