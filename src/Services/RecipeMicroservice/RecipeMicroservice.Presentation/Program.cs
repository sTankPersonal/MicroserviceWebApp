using BuildingBlocks.CrossCutting.Extensions;
using BuildingBlocks.CrossCutting.Middleware;
using BuildingBlocks.CrossCutting.Validation;
using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Infrastructure.Persistence;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<DefaultValidationFilter>();
});
ServiceCollectionExtensions.AddCrossCutting(builder.Services, builder.Configuration);

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
app.MapDefaultControllerRoute();

app.Run();
