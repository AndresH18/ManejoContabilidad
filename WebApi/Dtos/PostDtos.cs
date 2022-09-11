using ModelEntities;

namespace WebApi.Dtos;

public record CategoriaPost(string Name, string? Description) : PostModelRecord;

public record MarcaPost(string Name, string? Description) : PostModelRecord;

public record ProductoPost
    (string Name, string? Description, string Reference, string Code, decimal UnitPrice) : PostModelRecord;

public record ClientePost(string Name, TipoDocumento DocumentType, string DocumentNumber, string? Address,
    string? Email, string? PhoneNumber) : PostModelRecord;

public record FacturaPost(int ClienteId) : PostModelRecord;

public record InfoFacturaPost(int Id, string? NumeroFactura) : PostModelRecord;

public record DetallesFacturaPost(int FacturaId, int ProductoId, int Quantity);