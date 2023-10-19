using Microsoft.Extensions.DependencyInjection;
using Skeleton.FunctionalTests.Factory;
using Skeleton.Infrastructure.Presistence;

namespace Skeleton.FunctionalTests.Fixture;

public class DatabaseFixture
{
    public DatabaseFixture()
    {
        // ... initialize data in the test database ...
        Console.WriteLine("---> Initialize DatabaseFixture");
        var application = WebFactory.GetWebApplication();
        var services = application.Services.CreateScope();

        DbContext = services.ServiceProvider.GetRequiredService<SqlDbContext>();
        DbContext.Database.EnsureDeleted();
        DbContext.Database.EnsureCreated();

        Console.WriteLine("---> Get DbContext");
        HttpClient = application.CreateClient();
        Console.WriteLine("---> Create HttpClient");
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...        
    }

    public SqlDbContext DbContext { get; private set; }
    public HttpClient HttpClient { get; private set; }
}
