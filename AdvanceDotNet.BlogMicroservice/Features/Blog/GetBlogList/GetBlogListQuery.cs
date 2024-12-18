using AdvanceDotNet.Utlis;
using MediatR;

namespace AdvanceDotNet.BlogMicroservice.Features.Blog.GetBlogList
{
    public class GetBlogListQuery : IRequest<Result<GetBlogListResponse>>
    {
        public int PageNo {  get; set; }
        public int PageSize { get; set; }

        public GetBlogListQuery(int pageNo, int pageSize)
        {
            PageNo = pageNo;
            PageSize = pageSize;
        }
    }


}
