using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Invoice
{
    public int Id { get; set; }
    [StringLength(45)] public string InvoiceNumber { get; set; } = string.Empty;
    [Range(0, double.PositiveInfinity)] public double Price { get; set; } = 0;
    public string? Path { get; set; }

    /* Relationships */
    public int ClientId { get; set; }
    public virtual Client Client { get; set; } = default!;
}