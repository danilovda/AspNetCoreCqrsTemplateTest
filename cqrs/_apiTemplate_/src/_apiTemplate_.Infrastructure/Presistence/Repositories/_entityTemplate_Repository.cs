using _apiTemplate_.Application.Common.Interfaces.Persistence;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Infrastructure.Presistence.Repositories;
public class _entityTemplate_Repository : GenericRepository<_entityTemplate_>, I_entityTemplate_Repository
{
    private readonly SqlDbContext _dbContext;

    public _entityTemplate_Repository(SqlDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
