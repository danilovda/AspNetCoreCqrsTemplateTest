using Microsoft.EntityFrameworkCore;

namespace _apiTemplate_.Infrastructure.Presistence;
public class SqlDbContext : DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

    //public DbSet<Employee> Employees { get; set; }

}
