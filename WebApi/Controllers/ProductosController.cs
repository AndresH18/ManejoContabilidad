using DbContextLibrary.Repository;
using ModelEntities;

namespace WebApi.Controllers;

public class ProductosController : AbstractController<IProductoRepository, Producto>
{
    public ProductosController(IProductoRepository repo) : base(repo)
    {
    }
}