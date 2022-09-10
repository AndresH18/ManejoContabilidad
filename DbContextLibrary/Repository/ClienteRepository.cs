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

    public IEnumerable<Cliente> GetAll()
    {
        return _db.Clientes.AsNoTracking();
    }

    public Cliente? GetById(int id)
    {
        return _db.Clientes.FirstOrDefault(x => x.Id == id);
    }

    public void Update(Cliente entity)
    {
        _db.Clientes.Update(entity);
        _db.SaveChanges();
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
}