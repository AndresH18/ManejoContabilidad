using System.ComponentModel.DataAnnotations;

namespace ModelEntities;

public class Cliente : ICloneable
{
    [Key] public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public TipoDocumento TipoDocumento { get; set; } = default;
    public string NumeroDocumento { get; set; } = "123 233 9888";
    public string? Direccion { get; set; }
    public string? MunicipioId { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public string? TipoContribuyente { get; set; }
    public string? RegimenContable { get; set; }
    public string? Responsabilidad { get; set; }

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