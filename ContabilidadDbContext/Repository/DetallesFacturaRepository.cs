using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IDetallesFactura : ICompositeRepository<DetallesFactura>
{
}

public class DetallesFacturaRepository : IDetallesFactura
{
    private readonly ContabilidadDbContext _db = new();

    public DetallesFactura Create(DetallesFactura entity)
    {
        _db.DetallesFactura.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public IEnumerable<DetallesFactura> GetAll()
    {
        return _db.DetallesFactura.AsNoTracking();
    }

    public DetallesFactura? GetById(int facturaId, int productoFacturaId)
    {
        return _db.DetallesFactura.AsNoTracking()
            .FirstOrDefault(d => d.FacturaId == facturaId && d.ProductoFacturaId == productoFacturaId);
    }

    public void Update(DetallesFactura entity)
    {
        _db.DetallesFactura.Update(entity);
        _db.SaveChanges();
    }

    public void Delete(int facturaId, int productoFacturaId)
    {
        var d = GetById(facturaId, productoFacturaId);
        if (d != null)
        {
            _db.DetallesFactura.Remove(d);
            _db.SaveChanges();
        }
    }
}