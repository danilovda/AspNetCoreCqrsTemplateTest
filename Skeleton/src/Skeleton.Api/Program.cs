using Skeleton.Api;
using Skeleton.Application;
using Skeleton.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();

public partial class Program { }