using AdvanceDotNet.BlogMicroservice.Features.Blog;
using AdvanceDotNet.Database.Models;

namespace AdvanceDotNet.BlogMicroservice.Features
{ 
public class UnitOfWork : IUnitOfWork
{
    internal readonly AppDbContext _context;
    public IBlogRepository BlogRepository { get; set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        BlogRepository ??= new BlogRepository(context);
    }
}
}
