using BuildingBlocks.CrossCutting.Middleware;
using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Application;
using RecipeMicroservice.Infrastructure;
using RecipeMicroservice.Infrastructure.Persistence;



WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
Console.WriteLine(builder.Configuration.GetSection("CorrelationOptions")["HeaderName"] ?? "NOT FOUND");

// Add services to the container.
builder.Services.AddControllersWithViews();
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

using (IServiceScope scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<RecipeMicroserviceDbContext>().Database.Migrate();
}

app.UseStaticFiles();
app.Run();