﻿namespace ModelEntities;

public class ProductoFactura
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public string Marca { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Referencia { get; set; } = string.Empty;
    public decimal PrecioUnitario { get; set; }
    public string? Descripcion { get; set; }

    public virtual DetallesFactura DetallesFactura { get; set; }
}