using AdvanceDotNetBatch1.Database.Models;
using AdvanceDotNetBatch1.RepositoryPattern.Handlers;
using AdvanceDotNetBatch1.RepositoryPattern.Persistance.Reposistries;
using Microsoft.EntityFrameworkCore;

namespace AdvanceDotNetBatch1.RepositoryPattern.Extensions
{
    public static class DependencyInjectionExtension
    {

        public static IServiceCollection AddDependencies(this IServiceCollection services, WebApplicationBuilder builder)

        { 
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

    

            services.AddScoped<IBlogRepository, BlogRepository>();
    

            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();


            return services; 
        }
    }
}

