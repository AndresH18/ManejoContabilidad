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

    public async Task<Factura> CreateAsync(Factura entity)
    {
        entity.Id = 0;
        _db.Facturas.Add(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public IEnumerable<Factura> GetAll()
    {
        return _db.Facturas.ToList();
    }

    public async Task<IEnumerable<Factura>> GetAllAsync()
    {
        return await _db.Facturas.ToListAsync();
    }

    public Factura? GetById(int id)
    {
        return _db.Facturas.FirstOrDefault(f => f.Id == id);
    }

    public async Task<Factura?> GetByIdAsync(int id)
    {
        return await _db.Facturas.FirstOrDefaultAsync(f => f.Id == id);
    }

    public void Update(Factura entity)
    {
        _db.Facturas.Update(entity);
        _db.SaveChanges();
    }

    public async Task UpdateAsync(Factura entity)
    {
        _db.Facturas.Update(entity);
        await _db.SaveChangesAsync();
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

    public async Task DeleteAsync(int id)
    {
        var factura = await GetByIdAsync(id);
        if (factura != null)
        {
            _db.Facturas.Remove(factura);
            await _db.SaveChangesAsync();
        }
    }
}