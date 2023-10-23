using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _apiTemplate_.Infrastructure.Presistence;

namespace _apiTemplate_.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddPresistance(configuration);

        return services;
    }

    public static IServiceCollection AddPresistance(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        string connectionString = GetConnectionString(configuration);

        services.AddDbContext<SqlDbContext>(options =>
            options.UseSqlServer(connectionString));

        //services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }

    private static string GetConnectionString(ConfigurationManager configuration)
    {
        string dbServer = configuration["SqlSettings:DbServer"] ?? throw new NullReferenceException("SqlSettings:DbServer is null");
        string port = configuration["SqlSettings:Port"] ?? throw new NullReferenceException("SqlSettings:Port is null");
        string catalog = configuration["SqlSettings:Catalog"] ?? throw new NullReferenceException("SqlSettings:Catalog is null");
        string userId = configuration["SqlSettings:UserId"] ?? throw new NullReferenceException("SqlSettings:UserId is null");
        string password = configuration["SqlSettings:Password"] ?? throw new NullReferenceException("SqlSettings:Password is null");

        string connectionString = $"Server={dbServer},{port};Initial Catalog={catalog};User Id={userId};Password={password};Encrypt=false";//;TrustServerCertificate=True
        return connectionString;
    }

    private static string GetConnectionString2(ConfigurationManager configuration)
    {
        //string dbServer = configuration["SqlSettings:DbServer"] ?? throw new NullReferenceException("SqlSettings:DbServer is null");
        //string port = configuration["SqlSettings:Port"] ?? throw new NullReferenceException("SqlSettings:Port is null");
        //string catalog = configuration["SqlSettings:Catalog"] ?? throw new NullReferenceException("SqlSettings:Catalog is null");
        //string userId = configuration["SqlSettings:UserId"] ?? throw new NullReferenceException("SqlSettings:UserId is null");
        //string password = configuration["SqlSettings:Password"] ?? throw new NullReferenceException("SqlSettings:Password is null");
        string dbServer = @"(localdb)\\mssqllocaldb";
        string catalog = "_apiTemplate_Test";

        //string connectionString = $"Server={dbServer};Database={catalog};Trusted_Connection=True;MultipleActiveResultSets=true";
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=_apiTemplate_Test;Trusted_Connection=True;MultipleActiveResultSets=true";
        return connectionString;
    }
}
