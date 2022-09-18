using System.Text.Json.Serialization;

namespace ModelEntities;

public class Producto : IModel, ICloneable
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string? Codigo { get; set; } = string.Empty;
    public string? Referencia { get; set; } = string.Empty;
    public decimal PrecioUnitario { get; set; }
    public string? Descripcion { get; set; }

    // Categoria Relationship
    public int CategoriaId { get; set; }
    [JsonIgnore] public virtual Categoria? Categoria { get; set; }

    // Marca Relationship
    public int MarcaId { get; set; }
    [JsonIgnore] public virtual Marca? Marca { get; set; }

    [JsonIgnore] public List<DetallesFactura> DetallesFacturas { get; set; } = new();

    public void CopyFrom(Producto producto)
    {
        this.Nombre = producto.Nombre;
        this.Codigo = producto.Codigo;
        this.Referencia = producto.Referencia;
        this.PrecioUnitario = producto.PrecioUnitario;
        this.Descripcion = producto.Descripcion;
        this.CategoriaId = producto.CategoriaId;
        this.MarcaId = producto.MarcaId;
    }

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