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

    public async Task<InfoFactura> CreateAsync(InfoFactura entity)
    {
        _db.InfoFactura.Add(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public IEnumerable<InfoFactura> GetAll()
    {
        return _db.InfoFactura.ToList();
    }

    public async Task<IEnumerable<InfoFactura>> GetAllAsync()
    {
        return await _db.InfoFactura.ToListAsync();
    }

    public InfoFactura? GetById(int id)
    {
        return _db.InfoFactura.FirstOrDefault(i => i.Id == id);
    }

    public async Task<InfoFactura?> GetByIdAsync(int id)
    {
        return await _db.InfoFactura.FirstOrDefaultAsync(i => i.Id == id);
    }

    public void Update(InfoFactura entity)
    {
        _db.InfoFactura.Update(entity);
        _db.SaveChanges();
    }

    public async Task UpdateAsync(InfoFactura entity)
    {
        _db.InfoFactura.Update(entity);
        await _db.SaveChangesAsync();
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

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _db.InfoFactura.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}