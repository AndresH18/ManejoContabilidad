using AutoMapper;
using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;
using WebApi.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class FacturasController : AbstractController<IFacturaRepository, Factura, FacturaGet>
{
    public FacturasController(IFacturaRepository repo, IMapper mapper) : base(repo, mapper)
    {
    }
}