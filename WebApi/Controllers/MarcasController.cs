using AutoMapper;
using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;
using WebApi.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class MarcasController : AbstractController<IMarcaRepository, Marca, MarcaGet>
{
    public MarcasController(IMarcaRepository repo, IMapper mapper) : base(repo, mapper)
    {
    }
}