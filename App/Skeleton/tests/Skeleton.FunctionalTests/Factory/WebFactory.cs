using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skeleton.Infrastructure.Presistence;

namespace Skeleton.FunctionalTests.Factory;

internal class WebFactory
{
    public static WebApplicationFactory<Program> GetWebApplication()
        => new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

            string? sqlConnectionString = configuration.GetConnectionString("sqlConnectionStringsTest");
            Console.WriteLine($"---> sqlConnectionStrings: {sqlConnectionString}");

            if (sqlConnectionString is null) throw new NullReferenceException("sqlConnectionStrings is null");

            builder.ConfigureTestServices(services =>
            {
                var options = new DbContextOptionsBuilder<SqlDbContext>()
                                .UseSqlServer(sqlConnectionString)
                                .Options;
                services.AddSingleton(options);
                services.AddSingleton<SqlDbContext>();
            });

            Console.WriteLine($"---> Built ConfigureTestServices");
        });
}
