using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class ClientesController : AbstractController<IClienteRepository, Cliente>
{
    public ClientesController(IClienteRepository repo) : base(repo)
    {
    }
}