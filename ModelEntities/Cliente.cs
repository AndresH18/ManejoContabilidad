using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ModelEntities;

public class Cliente : IModel, ICloneable
{
    [Key] public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public TipoDocumento TipoDocumento { get; set; }
    public string NumeroDocumento { get; set; } = string.Empty;
    [JsonIgnore] public string? Direccion { get; set; }

    // [Required] 
    [JsonIgnore] public string? MunicipioId { get; set; }

    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    [JsonIgnore] public string? TipoContribuyente { get; set; }
    [JsonIgnore] public string? RegimenContable { get; set; }
    [JsonIgnore] public string? Responsabilidad { get; set; }

    [JsonIgnore] public virtual List<Factura> Facturas { get; set; } = new();

    public void CopyFrom(Cliente cliente)
    {
        this.TipoDocumento = cliente.TipoDocumento;
        this.Nombre = cliente.Nombre;
        this.NumeroDocumento = cliente.NumeroDocumento;
        this.Direccion = cliente.Direccion;
        this.Correo = cliente.Correo;
        this.Telefono = cliente.Telefono;
        this.TipoContribuyente = cliente.TipoContribuyente;
        this.RegimenContable = cliente.RegimenContable;
        this.Responsabilidad = cliente.Responsabilidad;
    }

    public object Clone()
    {
        return new Cliente
        {
            Id = Id,
            Nombre = Nombre,
            TipoDocumento = TipoDocumento,
            NumeroDocumento = NumeroDocumento,
            Direccion = Direccion,
            MunicipioId = MunicipioId,
            Correo = Correo,
            Telefono = Telefono,
            TipoContribuyente = TipoContribuyente,
            RegimenContable = RegimenContable,
            Responsabilidad = Responsabilidad
        };
    }
}