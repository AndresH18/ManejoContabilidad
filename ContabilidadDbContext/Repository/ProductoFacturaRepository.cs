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
        _db.ProductoFacturas.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public IEnumerable<ProductoFactura> GetAll()
    {
        return _db.ProductoFacturas.AsNoTracking();
    }

    public ProductoFactura? GetById(int id)
    {
        return _db.ProductoFacturas.AsNoTracking().FirstOrDefault(pf => pf.Id == id);
    }

    public void Update(ProductoFactura entity)
    {
        _db.ProductoFacturas.Update(entity);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var pf = GetById(id);
        if (pf != null)
        {
            _db.ProductoFacturas.Remove(pf);
            _db.SaveChanges();
        }
    }
}