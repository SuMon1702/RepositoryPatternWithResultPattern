using AdvanceDotNet.BlogMicroservice.Features;
using AdvanceDotNetBatch1.Database.Models;
using AdvanceDotNetBatch1.RepositoryPattern.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AdvanceDotNet.BlogMicroservice.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDependencies(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        builder.Services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(DependencyInjectionExtension).Assembly);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder
            .Services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        return services;
    }

}