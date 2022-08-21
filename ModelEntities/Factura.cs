using System.Text.Json.Serialization;

namespace ModelEntities;

public class Factura : IModel
{
    public int Id { get; set; }
    public int ClienteId { get; set; }

    // Relations
    [JsonIgnore] public virtual InfoFactura InfoFactura { get; set; }
    [JsonIgnore] public virtual Cliente Cliente { get; set; }
    [JsonIgnore] public virtual List<DetallesFactura> DetallesFacturas { get; set; } = new();
}