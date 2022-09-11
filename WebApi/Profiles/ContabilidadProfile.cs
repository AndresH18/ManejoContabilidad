using AutoMapper;
using ModelEntities;
using WebApi.Dtos;

namespace WebApi.Profiles;

internal class ContabilidadProfile : Profile
{
    public ContabilidadProfile()
    {
        #region Model -> Get Dto

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

        #endregion

        #region Model -> Post Dto

        CreateMap<CategoriaPost, Categoria>();
        CreateMap<MarcaPost, Marca>();
        CreateMap<FacturaPost, Factura>();
        CreateMap<InfoFacturaPost, InfoFactura>();

        CreateMap<ProductoPost, Producto>()
            .ForMember(dest => dest.Nombre,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Descripcion,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Referencia,
                opt => opt.MapFrom(src => src.Reference))
            .ForMember(dest => dest.Codigo,
                opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.PrecioUnitario,
                opt => opt.MapFrom(src => src.UnitPrice));

        CreateMap<ClientePost, Cliente>()
            .ForMember(dest => dest.Nombre,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.TipoDocumento,
                opt => opt.MapFrom(src => src.DocumentType))
            .ForMember(dest => dest.NumeroDocumento,
                opt => opt.MapFrom(src => src.DocumentNumber))
            .ForMember(dest => dest.Correo,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Direccion,
                opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Telefono,
                opt => opt.MapFrom(src => src.PhoneNumber));

        CreateMap<DetallesFacturaPost, DetallesFactura>()
            .ForMember(dest => dest.Cantidad,
                opt => opt.MapFrom(src => src.Quantity));

        #endregion
    }
}