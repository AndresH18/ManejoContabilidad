using System.Collections.Generic;
using System.Linq;
using DbContextLibrary;
using DbContextLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using ModelEntities;

namespace ContabilidadWinUI.Services;

public interface IProductsService
{
    IEnumerable<Categoria> GetAllCategorias();
    IEnumerable<Marca> GetAllMarcas();
}

public class ProductsService : IProductsService
{
    private readonly ContabilidadDbContext _db;

    public ProductsService(ContabilidadDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Categoria> GetAllCategorias()
    {
        return _db.Categorias.AsNoTracking().ToList();
    }

    public IEnumerable<Marca> GetAllMarcas()
    {
        return _db.Marcas.AsNoTracking().ToList();
    }
}