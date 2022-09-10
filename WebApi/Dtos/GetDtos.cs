using ModelEntities;

namespace WebApi.Dtos;

public record CategoriaGet(int Id, string Name, string? Description) : ModelRecord(Id);

public record MarcaGet(int Id, string Name, string? Description) : ModelRecord(Id);

public record ProductoGet(int Id, string Name, string? Description, decimal UnitPrice) : ModelRecord(Id);

public record ClienteGet(int Id, string Name, TipoDocumento DocumentType, string DocumentNumber) : ModelRecord(Id);

public record DetallesFacturaGet(int FacturaId, int ProductoId, int Amount);

public record FacturaGet(int Id, int ClienteId) : ModelRecord(Id);

public record InfoFacturaGet(int Id, string? NumeroFactura) : ModelRecord(Id);