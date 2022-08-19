namespace ModelEntities;

public class Factura
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    
    // Relations
    public virtual InfoFactura InfoFactura { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual List<DetallesFactura> DetallesFacturas { get; set; } = new();
}