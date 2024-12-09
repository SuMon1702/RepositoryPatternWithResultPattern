using AdvanceDotNetBatch1.Database.Models;
using Microsoft.EntityFrameworkCore;
using SMAdvanceDotNet.UnitOfWorkPattern.Persistance;
using SMAdvanceDotNet.UnitOfWorkPattern.Persistance.Repositories;

namespace SMDotNet.GenericRepositoryPattern.Dependencies
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
