using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Invoice
{
    public int Id { get; set; }

    /* Relationships */
    public int ClientId { get; set; }
    public virtual Client Client { get; set; } = default!;
}