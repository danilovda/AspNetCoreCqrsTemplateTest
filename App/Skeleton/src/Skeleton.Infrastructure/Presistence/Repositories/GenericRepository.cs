using Microsoft.EntityFrameworkCore;
using Skeleton.Application.Common.Interfaces.Persistence;
using Skeleton.Domain.Common.Interfaces;

namespace Skeleton.Infrastructure.Presistence.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class, IAggregateRoot
{
    private readonly SqlDbContext _dbContext;

    public GenericRepository(SqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> Insert(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> GetById(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task Delete(int id)
    {
        var t = await GetById(id);
        if (t is not null)
            await Delete(t);
    }

    public virtual async Task Delete(T entityToDelete)
    {
        if (_dbContext.Entry(entityToDelete).State == EntityState.Deleted)
        {
            _dbContext.Set<T>().Attach(entityToDelete);
        }
        _dbContext.Set<T>().Remove(entityToDelete);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task Update(T entityToUpdate)
    {
        _dbContext.Set<T>().Attach(entityToUpdate);
        _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
