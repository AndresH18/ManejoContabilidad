using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Shared.Models;

public class Invoice : ObservableValidator
{
    private int _invoiceNumber;
    private double _price;
    private DateTime _creationDate;
    private string? _path;
    private string _clientName;

    public int Id { get; set; }

    public int InvoiceNumber
    {
        get => _invoiceNumber;
        set => SetProperty(ref _invoiceNumber, value, true);
    }

    public DateTime CreationDate
    {
        get => _creationDate;
        set => SetProperty(ref _creationDate, value, true);
    }

    [Range(0, double.PositiveInfinity)]
    public double Price
    {
        get => _price;
        set => SetProperty(ref _price, value, true);
    }

    public string? Path
    {
        get => _path;
        set => SetProperty(ref _path, value, true);
    }

    /* Relationships */
    // public int ClientId { get; set; }
    // public virtual Client Client { get; set; } = default!;
    [StringLength(100), MinLength(1)]
    [Required]
    public string ClientName
    {
        get => _clientName;
        set => SetProperty(ref _clientName, value);
    }


    public Invoice()
    {
        _creationDate = DateTime.Now;
        _clientName = string.Empty;
    }

    public Invoice Clone()
    {
        return (Invoice) MemberwiseClone();
    }

    public void CopyFrom(Invoice source)
    {
        InvoiceNumber = source.InvoiceNumber;
        CreationDate = source.CreationDate;
        Price = source.Price;
        Path = source.Path;
        ClientName = source.ClientName;
    }

    public bool IsValid()
    {
        return HasErrors && !string.IsNullOrWhiteSpace(_clientName);
    }
}