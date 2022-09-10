using ModelEntities;

namespace WebApi.Dtos;

public record CategoriaGet(int Id, string Name, string? Description) : GetModelRecord(Id);

public record MarcaGet(int Id, string Name, string? Description) : GetModelRecord(Id);

public record ProductoGet(int Id, string Name, string? Description, decimal UnitPrice) : GetModelRecord(Id);

public record ClienteGet(int Id, string Name, TipoDocumento DocumentType, string DocumentNumber) : GetModelRecord(Id);

public record DetallesFacturaGet(int FacturaId, int ProductoId, int Amount);

public record FacturaGet(int Id, int ClienteId) : GetModelRecord(Id);

public record InfoFacturaGet(int Id, string? NumeroFactura) : GetModelRecord(Id);