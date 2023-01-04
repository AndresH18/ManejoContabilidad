using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Shared.Models;

public class Invoice : INotifyPropertyChanged
{
    private int _invoiceNumber;
    private double _price;
    private DateTime _creationTime;
    private string? _path;
    private string _clientName = default!;

    public int Id { get; set; }

    public int InvoiceNumber
    {
        get => _invoiceNumber;
        set
        {
            _invoiceNumber = value;
            OnPropertyChanged();
        }
    }

    public DateTime CreationDate
    {
        get => _creationTime;
        set
        {
            _creationTime = value;
            OnPropertyChanged();
        }
    }

    [Range(0, double.PositiveInfinity)]
    public double Price
    {
        get => _price;
        set
        {
            if (value < 0)
                return;
            _price = value;
            OnPropertyChanged();
        }
    }

    public string? Path
    {
        get => _path;
        set
        {
            _path = value;
            OnPropertyChanged();
        }
    }

    /* Relationships */
    // public int ClientId { get; set; }
    // public virtual Client Client { get; set; } = default!;
    [StringLength(100)]
    [Required]
    public string ClientName
    {
        get => _clientName;
        set
        {
            _clientName = value;
            OnPropertyChanged();
        }
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

    private void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}