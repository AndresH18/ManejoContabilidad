using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IFacturaRepository : IRepository<Factura>
{
}

public class FacturaRepository : IFacturaRepository
{
    private readonly ContabilidadDbContext _db;

    public FacturaRepository(ContabilidadDbContext db)
    {
        _db = db;
    }

    public Factura Create(Factura entity)
    {
        entity.Id = 0;
        _db.Facturas.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public IEnumerable<Factura> GetAll()
    {
        return _db.Facturas.AsNoTracking();
    }

    public Factura? GetById(int id)
    {
        return _db.Facturas.AsNoTracking().FirstOrDefault(f => f.Id == id);
    }

    public void Update(Factura entity)
    {
        _db.Facturas.Update(entity);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var factura = GetById(id);
        if (factura != null)
        {
            _db.Facturas.Remove(factura);
            _db.SaveChanges();
        }
    }
}