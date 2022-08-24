﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ModelEntities;

public class InfoFactura : IModel
{
    [Key, ForeignKey("Factura")]
    [Required]
    public int Id { get; set; }

    public string? NumeroFactura { get; set; }
    public DateTime? FechaEmision { get; set; }
    public string? TipoOperacion { get; set; }
    public string? TipoNegociacion { get; set; }
    public string? TipoEntrega { get; set; }
    public DateTime? FechaRecepcion { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public string? Prefijo { get; set; }
    public string? MedioPago { get; set; }
    public string? Plazo { get; set; }
    [JsonIgnore] public virtual Factura Factura { get; set; }
}