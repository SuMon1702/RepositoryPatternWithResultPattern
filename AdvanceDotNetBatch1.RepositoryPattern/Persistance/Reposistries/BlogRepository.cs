using AdvanceDotNetBatch1.Database.Models;
using AdvanceDotNetBatch1.RepositoryPattern.Models;
using AdvanceDotNetBatch1.Utlis;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdvanceDotNetBatch1.RepositoryPattern.Persistance.Reposistries
{
    public class BlogRepository : IBlogRepository  //this class talks to the database and fetches the data.To separate database-related operations from the rest of the application. It keeps the logic clean and organized.
    {
        internal readonly AppDbContext _context;  //context is a link to the database. It uses Entity Framework Core (EF Core) to interact with the database.

        public BlogRepository(AppDbContext context) // Constructor: BlogRepository receives an AppDbContext instance via Dependency Injection(DI)
        {
            _context = context;
        }

        public async Task<Result<List<BlogModel>>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs)
        {
            Result<List<BlogModel>> result;  //Returns the data wrapped in a Result object (success or failure).

            //Querying the database
            var query = _context.TblBlogs.Skip((pageNo - 1) * pageSize).Take(pageSize); // drr ka paginate class ko tee tant extension anay nk htoke pee yay htr dl. aelo tee tant ma yay bll dii mr yay ll ya dll.
            //Pagination: Instead of fetching all blogs, this line fetches only the blogs for the given page (e.g., Page 2 with 10 blogs per page).

            //Selecting the data into the BlogModel( Map Data to BlogModel)
            var lst = await query.Select(x => new BlogModel() //Each database row is converted into a BlogModel object.
            {
                BlogId = x.BlogId,
                BlogTitle = x.BlogTitle,
                BlogAuthor = x.BlogAuthor,
                BlogContent = x.BlogContent,
                IsDeleted = x.IsDeleted
            }).ToListAsync(cs);  //Converts the query into a list (List<BlogModel>) asynchronously with cancellation token.

            result = Result<List<BlogModel>>.Success(lst); //Wrap Data in a Result Object

            return result;  //The result, containing the blog list and a success status, is sent back to whoever called this method.
        }
    }
}

/*Final Analogy
Repository Class: The Waiter
The BlogRepository acts as the waiter who handles your request (fetch blogs) and talks to the kitchen (database).

Constructor: The Waiter's Training
The constructor (AppDbContext context) is like giving the waiter a connection to the kitchen so they can place orders (query the database).

GetBlogListAsync Method: The Waiter's Task
This method is the waiter's process:

Take your order (page number and size).
Fetch the right dishes (paginate and query).
Arrange them neatly (convert rows to BlogModel).
Deliver them to you (wrap in Result<T>).
Result Pattern: The Food Plating
The Result<T> ensures the food is always served properly:

Success? Delicious food (data).
Failure? Clear explanation (error message).


In the analogy:

The BlogRepository class is the waiter.
It performs the tasks like taking your order (method calls), fetching data (querying the database), and returning the result.

The IBlogRepository interface is like the menu.
It defines what the waiter can do (e.g., fetch a list of blogs), but not how they do it.

Analogy Summary:
IBlogRepository: The menu listing available services.
BlogRepository: The waiter who fulfills the services listed in the menu.*/
