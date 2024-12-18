using AdvanceDotNetBatch1.Utlis;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace AdvanceDotNet.BlogMicroservice.Features.Blog.GetBlogList
{
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<GetBlogListResponse>>
    {
        internal readonly IUnitOfWork _unitOfWork;

        public GetBlogListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetBlogListResponse>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            Result<GetBlogListResponse> result;
            try
            {
                var lst = await _unitOfWork.BlogRepository.Query(x => x.IsDeleted == false)
                    .Skip((request.PageNo - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);
                var model = new GetBlogListResponse(Blogs: lst);

                result = Result<GetBlogListResponse>.Success(model);
            }
            catch (Exception ex)
            {
                result = Result<GetBlogListResponse>.Fail(ex);
            }

        result:
            return result;
        }
    }
}
