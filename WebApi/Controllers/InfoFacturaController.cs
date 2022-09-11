using AutoMapper;
using DbContextLibrary.Repository;
using ModelEntities;
using WebApi.Dtos;

namespace WebApi.Controllers;

public class InfoFacturaController : AbstractController<IInfoFacturaRepository, InfoFactura, InfoFacturaGet, InfoFacturaPost>
{
    public InfoFacturaController(IInfoFacturaRepository repo, IMapper mapper) : base(repo, mapper)
    {
    }
}