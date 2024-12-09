using AdvanceDotNetBatch1.Database.Models;
using AdvanceDotNetBatch1.RepositoryPattern.Models;
using AdvanceDotNetBatch1.Utlis;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdvanceDotNetBatch1.RepositoryPattern.Persistance.Reposistries
{
    public class BlogRepository: IBlogRepository
    {
        internal readonly AppDbContext _context;  

        public BlogRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Result<List<BlogModel>>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cs)
        {
            Result<List<BlogModel>> result;  

            
            var query = _context.TblBlogs.Skip((pageNo - 1) * pageSize).Take(pageSize); 

            
            var lst = await query.Select(x => new BlogModel() 
            {
                BlogId = x.BlogId,
                BlogTitle = x.BlogTitle,
                BlogAuthor = x.BlogAuthor,
                BlogContent = x.BlogContent,
                IsDeleted = x.IsDeleted
            }).ToListAsync(cs);  

            result = Result<List<BlogModel>>.Success(lst); 

            return result;  
        }

        public async Task<Result<List<BlogRequestModel>>> CreateBlogListAsync(BlogRequestModel model, CancellationToken cs)
        {
            Result<List<BlogRequestModel>> result;
                
                    try
                    {
                        var item = new TblBlog()
                        {
                            
                            BlogTitle = model.BlogTitle,
                            BlogAuthor = model.BlogAuthor,
                            BlogContent = model.BlogContent,
                            IsDeleted = false
                        };
                       
                    await _context.TblBlogs.AddAsync(item, cs);
                    await _context.SaveChangesAsync(cs);

                result = Result<List<BlogRequestModel>>.Success(new List<BlogRequestModel> { model });


            }
                    catch (Exception ex)
                    {
                        result= Result<List<BlogRequestModel>>.Fail(ex);
                    }
            return result;
                }

        public async Task<Result<BlogRequestModel>> UpdateBlogAsync(int blogId, BlogRequestModel model, CancellationToken cs)
        {
            Result<BlogRequestModel> result;

            try
            {
                var item = await _context.TblBlogs.FirstOrDefaultAsync(x => x.BlogId == blogId, cs);

                if (item is null)
                {
                    result = Result<BlogRequestModel>.Fail("No Data Found");
                    return result;
                }
                item.BlogTitle = model.BlogTitle;
                item.BlogAuthor = model.BlogAuthor;
                item.BlogContent = model.BlogContent;

                _context.TblBlogs.Update(item);
                await _context.SaveChangesAsync(cs);

                result = Result<BlogRequestModel>.Success(model);
            }
            catch (Exception ex)
            {
                result = Result<BlogRequestModel>.Fail(ex);
            }

            return result;
        }

        public async Task<Result<BlogModel>> DeleteBlogAsync(int blogId, CancellationToken cs)
        {
            Result<BlogModel> result;

            try
            {
                var item = await _context.TblBlogs.FirstOrDefaultAsync(x => x.BlogId == blogId, cs);

                if (item is null)
                {
                    result = Result<BlogModel>.Fail("No Data Found");
                    return result;
                }

                item.IsDeleted = true;

               
                await _context.SaveChangesAsync(cs);

                result = Result<BlogModel>.Success();
            }

            catch (Exception ex)
            {
                result = Result<BlogModel>.Fail(ex);
            }
            return result;
        }

    }
    }



