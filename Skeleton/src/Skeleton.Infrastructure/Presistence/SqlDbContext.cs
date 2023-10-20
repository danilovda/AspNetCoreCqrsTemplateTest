using Microsoft.EntityFrameworkCore;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Infrastructure.Presistence;
public class SqlDbContext : DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }

}
