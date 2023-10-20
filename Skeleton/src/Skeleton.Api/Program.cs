using Skeleton.Api;
using Skeleton.Api.Endpoints;
using Skeleton.Api.Middleware;
using Skeleton.Application;
using Skeleton.Infrastructure;
using Skeleton.Infrastructure.Presistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

DbInitializer.Initialize(app);

//app.MapGet("/", () => "Hello World!");

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapEmployeeEndpoints();

app.Run();

public partial class Program { }