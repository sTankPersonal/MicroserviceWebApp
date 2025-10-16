using BuildingBlocks.CrossCutting.Extensions;
using BuildingBlocks.CrossCutting.Middleware;
using BuildingBlocks.CrossCutting.Validation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<DefaultValidationFilter>();
});
ServiceCollectionExtensions.AddCrossCutting(builder.Services, builder.Configuration);

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
