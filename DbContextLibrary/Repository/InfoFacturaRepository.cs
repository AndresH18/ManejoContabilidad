using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IInfoFacturaRepository : IRepository<InfoFactura>
{
}

public class InfoFacturaRepository : IInfoFacturaRepository
{
    private readonly ContabilidadDbContext _db;

    public InfoFacturaRepository(ContabilidadDbContext db)
    {
        _db = db;
    }

    public InfoFactura Create(InfoFactura entity)
    {
        _db.InfoFactura.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public IEnumerable<InfoFactura> GetAll()
    {
        return _db.InfoFactura.AsNoTracking();
    }

    public InfoFactura? GetById(int id)
    {
        return _db.InfoFactura.AsNoTracking().FirstOrDefault(i => i.Id == id);
    }

    public void Update(InfoFactura entity)
    {
        _db.InfoFactura.Update(entity);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _db.InfoFactura.Remove(entity);
            _db.SaveChanges();
        }
    }
}