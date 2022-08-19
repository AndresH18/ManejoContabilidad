namespace DbContextLibrary.Repository;

public interface IRepository<T> where T : class
{
    T Create(T entity);
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void Update(T entity);
    void Delete(int id);
}

public interface ICompositeRepository<T> where T : class
{
    T Create(T entity);
    IEnumerable<T> GetAll();
    T? GetById(int id1, int productoFacturaId);
    void Update(T entity);
    void Delete(int id1, int id2);
}
