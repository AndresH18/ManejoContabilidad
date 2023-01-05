using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Shared.Models;

public class InvoicePrintDto : ObservableValidator
{
    private double _price;
    public string Name { get; set; }
    public int InvoiceNumber { get; set; }
    public DateTime DateTime { get; set; }
    public TipoPago PaymentType { get; set; } = TipoPago.Pago;

    [Range(0, double.PositiveInfinity)]
    public double Price
    {
        get => _price;
        set => SetProperty(ref _price, value, true);
    }

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