﻿using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace DbContextLibrary.Repository;

public interface IMarcaRepository : IRepository<Marca>
{
}

public class MarcaRepository : IMarcaRepository
{
    private readonly ContabilidadDbContext _db = new();

    public Marca Create(Marca marca)
    {
        _db.Marcas.Add(marca);
        _db.SaveChanges();
        return marca;
    }

    public IEnumerable<Marca> GetAll()
    {
        return _db.Marcas.AsNoTracking();
    }

    public Marca? GetById(int id)
    {
        return _db.Marcas.AsNoTracking().FirstOrDefault(m => m.Id == id);
    }

    public void Update(Marca marca)
    {
        _db.Marcas.Update(marca);
        _db.SaveChanges();
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
}