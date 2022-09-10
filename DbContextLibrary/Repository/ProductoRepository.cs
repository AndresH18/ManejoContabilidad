using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IProductoRepository : IRepository<Producto>
{
}

public class ProductoRepository : IProductoRepository
{
    private readonly ContabilidadDbContext _db;

    public ProductoRepository(ContabilidadDbContext db)
    {
        _db = db;
    }

    public Producto Create(Producto entity)
    {
        entity.Id = 0;
        _db.Productos.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public IEnumerable<Producto> GetAll()
    {
        return _db.Productos.AsNoTracking().ToList();
    }

    public Producto? GetById(int id)
    {
        return _db.Productos.AsNoTracking().FirstOrDefault(p => p.Id == id);
    }

    public void Update(Producto entity)
    {
        _db.Productos.Update(entity);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var producto = GetById(id);
        if (producto != null)
        {
            _db.Productos.Remove(producto);
            _db.SaveChanges();
        }
    }
}