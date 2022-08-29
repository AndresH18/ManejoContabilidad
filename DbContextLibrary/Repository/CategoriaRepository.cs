using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface ICategoriaRepository : IRepository<Categoria>
{
}

public class CategoriaRepository : ICategoriaRepository
{
    private readonly ContabilidadDbContext _db = new();

    public Categoria Create(Categoria entity)
    {
        entity.Id = 0;
        _db.Categorias.Add(entity);
        _db.SaveChanges();
        return entity;
    }

    public IEnumerable<Categoria> GetAll()
    {
        return _db.Categorias.AsNoTracking();
    }

    public Categoria? GetById(int id)
    {
        return _db.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);
    }

    public void Update(Categoria entity)
    {
        _db.Categorias.Update(entity);
        _db.SaveChanges();
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
}