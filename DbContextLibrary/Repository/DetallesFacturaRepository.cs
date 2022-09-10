using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IDetallesFacturaRepository
{
    DetallesFactura Create(DetallesFactura detallesFactura);
    IEnumerable<DetallesFactura> GetAll();
    DetallesFactura? GetById(int facturaId, int productoId);
    void Update(DetallesFactura detallesFactura);
    void Delete(int facturaId, int productoId);
}

public class DetallesFacturaRepositoryRepository : IDetallesFacturaRepository
{
    private readonly ContabilidadDbContext _db;

    public DetallesFacturaRepositoryRepository(ContabilidadDbContext db)
    {
        _db = db;
    }

    public DetallesFactura Create(DetallesFactura entity)
    {
        _db.DetallesFactura.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public IEnumerable<DetallesFactura> GetAll()
    {
        return _db.DetallesFactura.AsNoTracking().ToList();
    }

    public DetallesFactura? GetById(int facturaId, int productoId)
    {
        return _db.DetallesFactura.AsNoTracking()
            .FirstOrDefault(d => d.FacturaId == facturaId && d.ProductoId == productoId);
    }

    public void Update(DetallesFactura entity)
    {
        _db.DetallesFactura.Update(entity);
        _db.SaveChanges();
    }

    public void Delete(int facturaId, int productoId)
    {
        var d = GetById(facturaId, productoId);
        if (d != null)
        {
            _db.DetallesFactura.Remove(d);
            _db.SaveChanges();
        }
    }
}