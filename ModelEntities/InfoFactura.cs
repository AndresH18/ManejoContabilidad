using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ModelEntities;

public class InfoFactura : IModel
{
    [Key, ForeignKey("Factura")]
    [Required]
    public int Id { get; set; }

    public string? NumeroFactura { get; set; }
    [JsonIgnore] public DateTime? FechaEmision { get; set; }
    [JsonIgnore] public string? TipoOperacion { get; set; }
    [JsonIgnore] public string? TipoNegociacion { get; set; }
    [JsonIgnore] public string? TipoEntrega { get; set; }
    [JsonIgnore] public DateTime? FechaRecepcion { get; set; }
    [JsonIgnore] public DateTime? FechaVencimiento { get; set; }
    [JsonIgnore] public string? Prefijo { get; set; }
    [JsonIgnore] public string? MedioPago { get; set; }
    [JsonIgnore] public string? Plazo { get; set; }

    [JsonIgnore] public virtual Factura? Factura { get; set; }
}