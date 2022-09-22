using System.Text.Json.Serialization;

namespace ModelEntities;

public class Marca : IModel, ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    [JsonIgnore] public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public void CopyFrom(object o)
    {
        if (o is not Marca marca)
            return;
        this.Name = marca.Name;
        this.Description = marca.Description;
    }

    public object Clone()
    {
        return new Marca
        {
            Id = Id,
            Name = Name,
            Description = Description,
        };
    }
}