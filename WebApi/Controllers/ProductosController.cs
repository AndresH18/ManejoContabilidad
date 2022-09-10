using AutoMapper;
using DbContextLibrary.Repository;
using ModelEntities;
using WebApi.Dtos;

namespace WebApi.Controllers;

public class ProductosController : AbstractController<IProductoRepository, Producto, ProductoGet>
{
    public ProductosController(IProductoRepository repo, IMapper mapper) : base(repo, mapper)
    {
    }
}