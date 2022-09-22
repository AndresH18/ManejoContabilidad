using Microsoft.EntityFrameworkCore;
using ModelEntities;
using System.Text.RegularExpressions;

namespace DbContextLibrary.Repository;

public interface IMarcaRepository : IRepository<Marca>
{
}

public class MarcaRepository : IMarcaRepository
{
    private readonly ContabilidadDbContext _db;

    public MarcaRepository(ContabilidadDbContext db)
    {
        _db = db;
    }

    public Marca Create(Marca marca)
    {
        marca.Id = 0;
        _db.Marcas.Add(marca);
        _db.SaveChanges();
        return marca;
    }

    public async Task<Marca> CreateAsync(Marca marca)
    {
        marca.Id = 0;
        _db.Marcas.Add(marca);
        await _db.SaveChangesAsync();
        return marca;
    }

    public IEnumerable<Marca> GetAll()
    {
        return _db.Marcas.ToList();
    }

    public async Task<IEnumerable<Marca>> GetAllAsync()
    {
        return await _db.Marcas.ToListAsync();
    }

    public Marca? GetById(int id)
    {
        return _db.Marcas.FirstOrDefault(m => m.Id == id);
    }

    public async Task<Marca?> GetByIdAsync(int id)
    {
        return await _db.Marcas.FirstOrDefaultAsync(m => m.Id == id);
    }

    public void Update(Marca marca)
    {
        _db.Marcas.Update(marca);
        _db.SaveChanges();
    }

    public async Task UpdateAsync(Marca marca)
    {
        _db.Marcas.Update(marca);
        await _db.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        var marca = GetById(id);
        if (marca != null)
        {
            _db.Marcas.Remove(marca);
            _db.SaveChanges();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var marca = await GetByIdAsync(id);
        if (marca != null)
        {
            _db.Marcas.Remove(marca);
            await _db.SaveChangesAsync();
        }
    }
}