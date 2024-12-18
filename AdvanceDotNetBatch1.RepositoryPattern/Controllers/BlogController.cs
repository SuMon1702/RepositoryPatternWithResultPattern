using AdvanceDotNet.RepositoryPattern.Models;
using AdvanceDotNet.RepositoryPattern.Persistance.Reposistries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using static System.Net.WebRequestMethods;

namespace AdvanceDotNet.RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        internal readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs)

        {
            var lst = await _blogRepository.GetBlogListAsync(pageNo, pageSize, cs);
            return Ok(lst);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogListAsync([FromBody] BlogRequestModel model, CancellationToken cs)
        {
            var item= await _blogRepository.CreateBlogListAsync(model, cs);
            return Ok(item);
        }

        [HttpPut("{blogId}")]
        public async Task<IActionResult> UpdateBlogAsync (int blogId, BlogRequestModel model, CancellationToken cs)
        {
            var item = await _blogRepository.UpdateBlogAsync(blogId, model, cs);
            return Ok(item);
        }

        [HttpDelete("{blogId}")]
        public async Task<IActionResult> DeleteBlogAsync(int blogId, CancellationToken cs)
        {
            var item = await _blogRepository.DeleteBlogAsync(blogId, cs);
            return Ok(item);
        }
    }

    
}