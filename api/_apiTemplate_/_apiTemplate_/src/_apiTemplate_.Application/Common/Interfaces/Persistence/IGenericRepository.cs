using _apiTemplate_.Domain.Common.Interfaces;

namespace _apiTemplate_.Application.Common.Interfaces.Persistence;
public interface IGenericRepository<T> where T : class, IAggregateRoot
{
    Task<T> Insert(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task Update(T entityToUpdate);
    Task Delete(int id);
}
