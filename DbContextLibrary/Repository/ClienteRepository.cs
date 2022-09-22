using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IClienteRepository : IRepository<Cliente>
{
}

public class ClienteRepository : IClienteRepository
{
    private readonly ContabilidadDbContext _db;

    public ClienteRepository(ContabilidadDbContext db)
    {
        _db = db;
    }

    public Cliente Create(Cliente entity)
    {
        entity.Id = 0;
        _db.Clientes.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public async Task<Cliente> CreateAsync(Cliente entity)
    {
        entity.Id = 0;
        _db.Clientes.Add(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public IEnumerable<Cliente> GetAll()
    {
        return _db.Clientes.ToList();
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _db.Clientes.ToListAsync();
    }

    public Cliente? GetById(int id)
    {
        return _db.Clientes.FirstOrDefault(x => x.Id == id);
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _db.Clientes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Update(Cliente entity)
    {
        _db.Clientes.Update(entity);
        _db.SaveChanges();
    }

    public async Task UpdateAsync(Cliente entity)
    {
        _db.Clientes.Update(entity);
        await _db.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        var cliente = GetById(id);
        if (cliente != null)
        {
            _db.Clientes.Remove(cliente);
            _db.SaveChanges();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var cliente = await GetByIdAsync(id);
        if (cliente != null)
        {
            _db.Clientes.Remove(cliente);
            await _db.SaveChangesAsync();
        }
    }
}