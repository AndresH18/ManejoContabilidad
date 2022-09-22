using IModel = ModelEntities.IModel;

namespace DbContextLibrary.Repository;

public interface IRepository<T> where T : class, IModel
{
    T Create(T entity);
    Task<T> CreateAsync(T entity);
    IEnumerable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    T? GetById(int id);
    Task<T?> GetByIdAsync(int id);
    void Update(T entity);
    Task UpdateAsync(T entity);
    void Delete(int id);
    Task DeleteAsync(int id);
}