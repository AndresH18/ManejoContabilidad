using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Invoice
{
    public int Id { get; set; }
    public int InvoiceNumber { get; set; }
    [Range(0, double.PositiveInfinity)] public double Price { get; set; } = 0;

    public string? Path { get; set; }

    /* Relationships */
    // public int ClientId { get; set; }
    // public virtual Client Client { get; set; } = default!;
    [StringLength(100)] [Required] public string ClientName { get; set; } = default!;

    public Invoice Clone()
    {
        return (Invoice) MemberwiseClone();
    }
}