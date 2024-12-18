using AdvanceDotNet.Database.Models;
using AdvanceDotNet.RepositoryPattern.Handlers;
using AdvanceDotNet.RepositoryPattern.Persistance.Reposistries;
using Microsoft.EntityFrameworkCore;

namespace AdvanceDotNet.RepositoryPattern.Extensions
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

