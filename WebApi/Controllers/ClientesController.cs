using AutoMapper;
using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;
using WebApi.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class ClientesController : AbstractController<IClienteRepository, Cliente, ClienteGet>
{
    public ClientesController(IClienteRepository repo, IMapper mapper) : base(repo, mapper)
    {
    }
}