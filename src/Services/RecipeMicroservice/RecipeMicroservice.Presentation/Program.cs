using Microsoft.EntityFrameworkCore;

using BuildingBlocks.CrossCutting.Extensions;
using BuildingBlocks.CrossCutting.Middleware;
using BuildingBlocks.CrossCutting.Validation;
using RecipeMicroservice.Infrastructure.Persistence;
using RecipeMicroservice.Application;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<DefaultValidationFilter>();
});
builder.Services.AddCrossCutting(builder.Configuration);    //BuildingBlocks CrossCutting
builder.Services.AddApplicationServices();                  //RecipeMicroservice Application Layer
builder.Services.AddDbContext<RecipeMicroserviceDbContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("NEON_CONNECTION"));
});

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
    var db = scope.ServiceProvider.GetRequiredService<RecipeMicroserviceDbContext>();
    db.Database.Migrate();
}

app.UseStaticFiles();
app.Run();
