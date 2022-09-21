using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface ICategoriaRepository : IRepository<Categoria>
{
}

public class CategoriaRepository : ICategoriaRepository
{
    private readonly ContabilidadDbContext _db;

    public CategoriaRepository(ContabilidadDbContext db)
    {
        _db = db;
    }

    public Categoria Create(Categoria entity)
    {
        entity.Id = 0;
        _db.Categorias.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public async Task<Categoria> CreateAsync(Categoria entity)
    {
        entity.Id = 0;
        _db.Categorias.Add(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public IEnumerable<Categoria> GetAll()
    {
        return _db.Categorias.ToList();
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _db.Categorias.ToListAsync();
    }

    public Categoria? GetById(int id)
    {
        return _db.Categorias.FirstOrDefault(c => c.Id == id);
    }

    public async Task<Categoria?> GetByIdAsync(int id)
    {
        return await _db.Categorias.FirstOrDefaultAsync(c => c.Id == id);
    }

    public void Update(Categoria entity)
    {
        _db.Categorias.Update(entity);
        _db.SaveChanges();
    }

    public async Task UpdateAsync(Categoria entity)
    {
        _db.Categorias.Update(entity);
        await _db.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        var categoria = GetById(id);
        if (categoria != null)
        {
            _db.Categorias.Remove(categoria);
            _db.SaveChanges();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var categoria = await GetByIdAsync(id);
        if (categoria != null)
        {
            _db.Categorias.Remove(categoria);
            await _db.SaveChangesAsync();
        }
    }
}