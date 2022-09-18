using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ModelEntities;

public class DetallesFactura
{
    [Required] public int FacturaId { get; set; }
    public int Cantidad { get; set; }

    [Required] public int ProductoId { get; set; }

    [JsonIgnore] public virtual Factura? Factura { get; set; }
    [JsonIgnore] public virtual Producto? Producto { get; set; }


    public void CopyFrom(DetallesFactura detallesFactura)
    {
        this.FacturaId = detallesFactura.FacturaId;
        this.ProductoId = detallesFactura.ProductoId;
        this.Cantidad = detallesFactura.Cantidad;
    }
}