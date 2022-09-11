using AutoMapper;
using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;
using WebApi.Dtos;

namespace WebApi.Controllers;

public class CategoriasController : AbstractController<ICategoriaRepository, Categoria, CategoriaGet, CategoriaPost>
{
    public CategoriasController(ICategoriaRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}