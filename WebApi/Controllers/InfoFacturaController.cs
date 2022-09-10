using DbContextLibrary.Repository;
using ModelEntities;

namespace WebApi.Controllers;

public class InfoFacturaController : AbstractController<IInfoFacturaRepository, InfoFactura>
{
    public InfoFacturaController(IInfoFacturaRepository repo) : base(repo)
    {
    }
}