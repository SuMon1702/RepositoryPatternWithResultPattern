using AdvanceDotNetBatch1.shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMAdvanceDotNet.UnitOfWorkPattern.Persistance;

namespace SMAdvanceDotNet.UnitOfWorkPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        internal readonly IUnitOfWork _unitOfWork;

        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogAsync(int pageNo, int pageSize, CancellationToken cs)
        {
            var query = _unitOfWork.BlogRepository.Query().Paginate(pageNo, pageSize);
            var lst = await query.ToListAsync(cs);

            return Ok(lst);
        }
    }
}
