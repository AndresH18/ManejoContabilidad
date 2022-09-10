using AutoMapper;
using ModelEntities;
using WebApi.Dtos;

namespace WebApi.Profiles;

internal class ContabilidadProfile : Profile
{
    public ContabilidadProfile()
    {
        CreateMap<Categoria, CategoriaGet>();
        CreateMap<Marca, MarcaGet>();
        CreateMap<Factura, FacturaGet>();
        CreateMap<InfoFactura, InfoFacturaGet>();

        CreateMap<Producto, ProductoGet>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.UnitPrice,
                opt => opt.MapFrom(src => src.PrecioUnitario));

        CreateMap<Cliente, ClienteGet>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.DocumentType,
                opt => opt.MapFrom(src => src.TipoDocumento))
            .ForMember(dest => dest.DocumentNumber,
                opt => opt.MapFrom(src => src.NumeroDocumento));
        
        CreateMap<DetallesFactura, DetallesFacturaGet>()
            .ForMember(dest => dest.Amount,
                opt => opt.MapFrom(src => src.Cantidad));
    }
}