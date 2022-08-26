using IModel = ModelEntities.IModel;

namespace DbContextLibrary.Repository;

public interface IRepository<T> where T : class, IModel
{
    T Create(T entity);
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void Update(T entity);
    void Delete(int id);
}
