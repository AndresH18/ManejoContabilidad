namespace DbContextLibrary.Repository;

public interface IRepository<T>
{
    T Create(T entity);
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void Update(T entity);
    void Delete(int id);
}