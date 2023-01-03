using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class InvoicePrintDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int InvoiceNumber { get; set; }
    public DateTime DateTime { get; set; }

    public TipoPago PaymentType { get; set; } = TipoPago.Pago;

    public InvoicePrintDto(Invoice invoice)
    {
        Name = invoice.ClientName;
        Price = invoice.Price;
        InvoiceNumber = invoice.InvoiceNumber;
    }

    public enum TipoPago
    {
        Pago,
        Abono
    }
}