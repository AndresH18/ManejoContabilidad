using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IDetallesFacturaRepository
{
    DetallesFactura Create(DetallesFactura detallesFactura);
    Task<DetallesFactura> CreateAsync(DetallesFactura detallesFactura);
    IEnumerable<DetallesFactura> GetAll();
    Task<IEnumerable<DetallesFactura>> GetAllAsync();
    DetallesFactura? GetById(int facturaId, int productoId);
    Task<DetallesFactura?> GetByIdAsync(int facturaId, int productoId);
    void Update(DetallesFactura detallesFactura);
    Task UpdateAsync(DetallesFactura detallesFactura);
    void Delete(int facturaId, int productoId);
    Task DeleteAsync(int facturaId, int productoId);
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

    public async Task<DetallesFactura> CreateAsync(DetallesFactura detallesFactura)
    {
        _db.DetallesFactura.Add(detallesFactura);
        await _db.SaveChangesAsync();
        return detallesFactura;
    }

    public IEnumerable<DetallesFactura> GetAll()
    {
        return _db.DetallesFactura.ToList();
    }

    public async Task<IEnumerable<DetallesFactura>> GetAllAsync()
    {
        return await _db.DetallesFactura.ToListAsync();
    }

    public DetallesFactura? GetById(int facturaId, int productoId)
    {
        return _db.DetallesFactura
            .FirstOrDefault(d => d.FacturaId == facturaId && d.ProductoId == productoId);
    }

    public async Task<DetallesFactura?> GetByIdAsync(int facturaId, int productoId)
    {
        return await _db.DetallesFactura
            .FirstOrDefaultAsync(d => d.FacturaId == facturaId && d.ProductoId == productoId);
    }

    public void Update(DetallesFactura entity)
    {
        _db.DetallesFactura.Update(entity);
        _db.SaveChanges();
    }

    public async Task UpdateAsync(DetallesFactura detallesFactura)
    {
        _db.DetallesFactura.Update(detallesFactura);
        await _db.SaveChangesAsync();
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

    public async Task DeleteAsync(int facturaId, int productoId)
    {
        var d = await GetByIdAsync(facturaId, productoId);
        if (d != null)
        {
            _db.DetallesFactura.Remove(d);
            await _db.SaveChangesAsync();
        }
    }
}