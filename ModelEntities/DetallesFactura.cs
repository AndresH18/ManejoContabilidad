using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ModelEntities;

public class DetallesFactura
{
    [Required] public int FacturaId { get; set; }
    [Required] public int ProductoFacturaId { get; set; }
    public int Cantidad { get; set; }

    [JsonIgnore] public virtual Factura? Factura { get; set; }
    [JsonIgnore] public virtual ProductoFactura? ProductoFactura { get; set; }
}