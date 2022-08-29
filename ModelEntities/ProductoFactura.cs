using System.Text.Json.Serialization;

namespace ModelEntities;

public class ProductoFactura : IModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    [JsonIgnore] public string Codigo { get; set; } = string.Empty;
    [JsonIgnore] public string Referencia { get; set; } = string.Empty;
    [JsonIgnore] public decimal PrecioUnitario { get; set; }
    [JsonIgnore] public string? Descripcion { get; set; }

    // Categoria Relationship
    public int? CategoriaId { get; set; }
    [JsonIgnore] public virtual Categoria? Categoria { get; set; }

    // Marca Relationship
    public int MarcaId { get; set; }
    [JsonIgnore] public virtual Marca? Marca { get; set; }
    
    // DetallesFactura Relationship
    [JsonIgnore] public virtual DetallesFactura? DetallesFactura { get; set; }
}