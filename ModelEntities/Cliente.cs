namespace ModelEntities;

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string TipoDocumento { get; set; } = "NIT";
    public string NumeroDocumento { get; set; } = "123 233 9888";
    public string Direccion { get; set; }
    public int MunicipioId { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public string TipoContribuyente { get; set; }
    public string RegimenContable { get; set; }
    public string Responsabilidad { get; set; }
}