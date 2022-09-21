using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IProductoRepository : IRepository<Producto>
{
}

public class ProductoRepository : IProductoRepository
{
    private readonly ContabilidadDbContext _db;

    public ProductoRepository(ContabilidadDbContext db)
    {
        _db = db;
    }

    public Producto Create(Producto entity)
    {
        entity.Id = 0;
        _db.Productos.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public async Task<Producto> CreateAsync(Producto entity)
    {
        entity.Id = 0;
        await _db.Productos.AddAsync(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public IEnumerable<Producto> GetAll()
    {
        return _db.Productos
            .Include(p => p.Categoria)
            .Include(p => p.Marca)
            .ToList();
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _db.Productos
            .Include(p => p.Categoria)
            .Include(p => p.Marca)
            .ToListAsync();
    }

    public Producto? GetById(int id)
    {
        return _db.Productos
            .Include(p => p.Categoria)
            .Include(p => p.Marca)
            .FirstOrDefault(p => p.Id == id);
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _db.Productos
            .Include(p => p.Categoria)
            .Include(p => p.Marca)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Update(Producto entity)
    {
        _db.Productos.Update(entity);
        _db.SaveChanges();
    }

    public async Task UpdateAsync(Producto entity)
    {
        _db.Productos.Update(entity);
        await _db.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        var producto = GetById(id);
        if (producto != null)
        {
            _db.Productos.Remove(producto);
            _db.SaveChanges();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var producto = await GetByIdAsync(id);
        if (producto != null)
        {
            _db.Productos.Remove(producto);
            await _db.SaveChangesAsync();
        }
    }
}