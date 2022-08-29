using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IProductoFacturaRepository : IRepository<ProductoFactura>
{
}

public class ProductoFacturaRepository : IProductoFacturaRepository
{
    private readonly ContabilidadDbContext _db = new();

    public ProductoFactura Create(ProductoFactura entity)
    {
        entity.Id = 0;
        _db.ProductoFactura.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public IEnumerable<ProductoFactura> GetAll()
    {
        return _db.ProductoFactura.AsNoTracking();
    }

    public ProductoFactura? GetById(int id)
    {
        return _db.ProductoFactura.AsNoTracking().FirstOrDefault(pf => pf.Id == id);
    }

    public void Update(ProductoFactura entity)
    {
        _db.ProductoFactura.Update(entity);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var pf = GetById(id);
        if (pf != null)
        {
            _db.ProductoFactura.Remove(pf);
            _db.SaveChanges();
        }
    }
}