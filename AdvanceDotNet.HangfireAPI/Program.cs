using Hangfire;
using Hangfire.Common;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(opt =>
{
    opt.UseSqlServerStorage(builder.Configuration.GetConnectionString("DbConnection"))
       .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings();
});

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHangfireDashboard("/hangfire");

app.UseAuthorization();

app.MapControllers();

//BackgroundJob.Enqueue(() => Console.WriteLine("Fire and Forget job"));

//BackgroundJob.Schedule(() => Console.WriteLine("Delay Job Sample"), TimeSpan.FromSeconds(30));

var Jobid = Guid.NewGuid().ToString();
//RecurringJob.AddOrUpdate(Jobid, () => Console.WriteLine("Recurring Job"), Cron.Minutely);
//RecurringJob.AddOrUpdate(Jobid, () => Console.WriteLine("Recurring Job"), "0 9 * * *");
//RecurringJob.AddOrUpdate(Jobid, () => Console.WriteLine("Recurring Job"), "0 10 * * 1"); // min hour date month day



var firstJobid = BackgroundJob.Enqueue( () => Console.WriteLine("First job executed"));
BackgroundJob.ContinueWith(firstJobid, () => Console.WriteLine("Continuation job executed"));




app.Run();
