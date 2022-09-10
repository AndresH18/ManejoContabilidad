using DbContextLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelEntities;

namespace WebApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class FacturasController : AbstractController<IFacturaRepository, Factura>
{
    public FacturasController(IFacturaRepository repo) : base(repo)
    {
    }
}