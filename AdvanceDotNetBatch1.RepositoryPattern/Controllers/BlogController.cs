using AdvanceDotNetBatch1.RepositoryPattern.Persistance.Reposistries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace AdvanceDotNetBatch1.RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        internal readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository) //This is a constructor with a parameter passed to the constructor that provides an implementation of the IBlogRepository.This is typically injected by the Dependency Injection(DI) system.
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
       
        public async Task<IActionResult> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs)

   /*async: Indicates this method runs asynchronously, allowing non-blocking operations.
   Task: The return type for an asynchronous operation.
   IActionResult: Represents the HTTP response returned to the client(e.g., OK, BadRequest).*/

        {
            var lst = await _blogRepository.GetBlogListAsync(pageNo, pageSize, cs);
            return Ok(lst);
        }
    }

}

/*Simplified Analogy
Think of BlogController as a waiter in a restaurant:
A customer (the client) asks for the menu (GET request for blogs).
The waiter takes the order (calls the repository to fetch data).
The chef (repository) prepares the dish (retrieves data from the database).
The waiter serves the dish (returns the blog list).*/