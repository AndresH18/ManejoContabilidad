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


    public void CopyFrom(object o)
    {
        if (o is not InfoFactura infoFactura)
            return;
        this.NumeroFactura = infoFactura.NumeroFactura;
        this.FechaEmision = infoFactura.FechaEmision;
        this.TipoOperacion = infoFactura.TipoOperacion;
        this.TipoNegociacion = infoFactura.TipoNegociacion;
        this.TipoEntrega = infoFactura.TipoEntrega;
        this.FechaRecepcion = infoFactura.FechaRecepcion;
        this.FechaVencimiento = infoFactura.FechaVencimiento;
        this.Prefijo = infoFactura.Prefijo;
        this.MedioPago = infoFactura.MedioPago;
        this.Plazo = infoFactura.Plazo;
    }
}