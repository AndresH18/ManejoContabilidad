using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

public class CategoriasController : AbstractController<ICategoriaRepository, Categoria>
{
    public CategoriasController(ICategoriaRepository repository) : base(repository)
    {
    }
}