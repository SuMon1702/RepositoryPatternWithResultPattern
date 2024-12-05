using AdvanceDotNetBatch1.Database.Models;
using AdvanceDotNetBatch1.RepositoryPattern.Persistance.Reposistries;
using Microsoft.EntityFrameworkCore;

namespace AdvanceDotNetBatch1.RepositoryPattern.Extensions
{
    public static class DependencyInjectionExtension
    {
        // IServiceCollection is a built-in C# interface that holds the list of services your application uses
        public static IServiceCollection AddDependencies(this IServiceCollection services, WebApplicationBuilder builder)

    /*public: This method can be called from anywhere in the project.
    static: You don’t need to create an object to use this method.
    IServiceCollection: A built-in C# interface that holds the list of services your application uses.
    AddDependencies: The name of the method. It describes what the method does (adds dependencies).
    this: Makes this an extension method, so it can be called like services.AddDependencies().
    IServiceCollection services: The list of services to which we will add things like the database or repositories.
    WebApplicationBuilder builder: A parameter to pass the application's configuration settings (like exception handling).*/
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

    /*services.AddDbContext<AppDbContext>: Adds a database connection for AppDbContext to the services list.
    AppDbContext: A class that represents the database in the application.
    opt =>: A lambda expression used to define options for the database.
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking): Configures the database queries so they don’t track changes, making them faster for read-only operations.*/

            services.AddScoped<IBlogRepository, BlogRepository>();
    /*services.AddScoped<>: Registers IBlogRepository and BlogRepository with the services.
    Scoped: Creates a new BlogRepository object for each HTTP request.
    IBlogRepository: The interface that defines how you interact with the BlogRepository.
    BlogRepository: The actual implementation of IBlogRepository.*/

            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
      /*services.AddControllers(): Adds support for controllers that handle HTTP requests.
       .AddJsonOptions(): Configures how JSON data is handled.
        opt.JsonSerializerOptions.PropertyNamingPolicy = null: Disables changing property names in JSON (e.g., keeps BlogTitle instead of blog_title).*/
           

            return services; // Returns the updated list of services so they can be used in the application
        }
    }
}

/*Purpose:
This class sets up all the dependencies your application needs to run, like:

Connecting to a database.
Using repositories for business logic.
Handling exceptions.
Managing JSON formatting.
How it works:

It is an extension method for IServiceCollection.
You call it once in your Program.cs file to configure your application.*/

/*Simplified Analogy
Think of this like setting up a kitchen before cooking:

Database (AddDbContext): Like installing a stove to cook food.
Repositories (AddScoped): Like hiring chefs for specific tasks (e.g., baking).
Controllers (AddControllers): Like setting up serving plates to deliver food.
Error Handling (AddExceptionHandler): Like a fire extinguisher for accidents.
Standardized Errors (AddProblemDetails): Like adding clear labels for allergens on the menu.
Once the kitchen is set up, you’re ready to serve customers (handle requests).*/