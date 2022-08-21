using DbContextLibrary.Repository;
using ModelEntities;

namespace WebApi.Controllers;

public class ProductoFacturaController : AbstractController<IProductoFacturaRepository, ProductoFactura>
{
    public ProductoFacturaController(IProductoFacturaRepository repo) : base(repo)
    {
    }
}