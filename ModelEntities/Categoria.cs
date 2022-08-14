﻿namespace ModelEntities;

public class Categoria
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}