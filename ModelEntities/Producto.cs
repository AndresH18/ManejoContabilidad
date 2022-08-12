namespace ModelEntities;

public class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    // TODO: Map relationship for Entity Framework Core
    public int CategoriaId { get; set; }

    // TODO: Map relationship for Entity Framework Core
    public int MarcaId { get; set; }

    public string Codigo { get; set; } = string.Empty;
    public string Referencia { get; set; } = string.Empty;
    public decimal PrecioUnitario { get; set; }
    public string? Descripcion { get; set; }
}