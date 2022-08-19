using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities;

public class DetallesFactura
{
    [Required] public int FacturaId { get; set; }
    [Required] public int ProductoFacturaId { get; set; }
    public int Cantidad { get; set; }

    public virtual Factura Factura { get; set; }
    public virtual ProductoFactura ProductoFactura { get; set; }
}