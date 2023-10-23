using _apiTemplate_.Api;
using _apiTemplate_.Api.Middleware;
using _apiTemplate_.Application;
using _apiTemplate_.Infrastructure;
using _apiTemplate_.Infrastructure.Presistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

//DbInitializer.Initialize(app);

app.MapGet("/", () => "Hello World!");
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();

public partial class Program { }