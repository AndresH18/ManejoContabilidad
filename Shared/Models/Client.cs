using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Client
{
    public int Id { get; set; }

    [Required] public string Name { get; set; } = default!;

    [Required] public string Document { get; set; } = default!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    /* Relationships */
    public virtual List<Invoice> Invoices { get; set; } = new();
}