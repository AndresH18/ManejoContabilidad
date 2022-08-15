namespace ModelEntities;

public class Producto : ICloneable
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Referencia { get; set; } = string.Empty;
    public decimal PrecioUnitario { get; set; }
    public string? Descripcion { get; set; }

    // Categoria Relationship
    public int? CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }

    // Marca Relationship
    public int MarcaId { get; set; }
    public virtual Marca Marca { get; set; }


    public object Clone()
    {
        return new Producto
        {
            Id = Id,
            Nombre = Nombre,
            CategoriaId = CategoriaId,
            Categoria = Categoria,
            MarcaId = MarcaId,
            Marca = Marca,
            Descripcion = Descripcion,
            Codigo = Codigo,
            PrecioUnitario = PrecioUnitario,
            Referencia = Referencia
        };
    }
}