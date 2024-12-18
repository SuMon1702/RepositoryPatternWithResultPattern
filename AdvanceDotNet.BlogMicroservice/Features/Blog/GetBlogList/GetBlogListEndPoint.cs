using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceDotNet.BlogMicroservice.Features.Blog.GetBlogList
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBlogListEndPoint : ControllerBase
    {
        internal readonly ISender _sender;

        public GetBlogListEndPoint(ISender sender)
        {
            _sender = sender;
        }

        // https://localhost:7146/gateway/Blog/GetBlogList?pageNo=1&pageSize=10
        [HttpGet("GetBlogList")]
        public async Task<IActionResult> GetBlogs(int pageNo, int pageSize, CancellationToken cs)
        {
            var query = new GetBlogListQuery(pageNo, pageSize);
            var result = await _sender.Send(query, cs);

            return Ok(result);
        }
    }
}
