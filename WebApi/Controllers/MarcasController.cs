using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class MarcasController : AbstractController<IMarcaRepository, Marca>
{
    public MarcasController(IMarcaRepository repo) : base(repo)
    {
    }
}