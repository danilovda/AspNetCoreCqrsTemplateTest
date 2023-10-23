using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _apiTemplate_.Infrastructure.Presistence;
public static class DbInitializer
{
    public static void Initialize(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            if (serviceScope is not null)
            {
                SeedData(serviceScope.ServiceProvider.GetService<SqlDbContext>()!);
            }
            else            
                throw new NullReferenceException(nameof(serviceScope));
        }
    }
    private static void SeedData(SqlDbContext context)
    {
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
}
