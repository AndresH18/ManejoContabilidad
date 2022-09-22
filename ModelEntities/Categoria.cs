using System.Text.Json.Serialization;

namespace ModelEntities;

public class Categoria : IModel, ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    [JsonIgnore] public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public void CopyFrom(object o)
    {
        if (o is not Categoria categoria) return;
        this.Name = categoria.Name;
        this.Description = categoria.Description;
    }


    public object Clone()
    {
        return new Categoria
        {
            Id = Id,
            Name = Name,
            Description = Description,
        };
    }
}