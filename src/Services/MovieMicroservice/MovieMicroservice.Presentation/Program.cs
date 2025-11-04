using BuildingBlocks.CrossCutting.Middleware;
using BuildingBlocks.CrossCutting.Validation;
using Microsoft.EntityFrameworkCore;
using MovieMicroservice.Application;
using MovieMicroservice.Infrastructure;
using MovieMicroservice.Infrastructure.Persistence;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<DefaultValidationFilter>();
});
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);


builder.Services.AddAuthorization();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<CorrelationMiddleware>();
app.UseMiddleware<LoggingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MovieMicroserviceDbContext>();
    db.Database.Migrate();
}

app.UseStaticFiles();
app.Run();