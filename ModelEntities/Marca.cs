namespace ModelEntities;

public class Marca : ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

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