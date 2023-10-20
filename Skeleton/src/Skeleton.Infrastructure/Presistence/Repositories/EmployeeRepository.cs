using Skeleton.Application.Common.Interfaces.Persistence;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Infrastructure.Presistence.Repositories;
public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    private readonly SqlDbContext _dbContext;

    public EmployeeRepository(SqlDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
