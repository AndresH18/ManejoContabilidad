using Models = Shared.Models;

namespace Shared;

public interface IExcelWriter : IDisposable
{
    public bool IsVisible { get; set; }
    public void Write(Models::InvoicePrintDto invoiceDto);

    public void Print(bool preview = true);

    void ReloadSettings(ExcelConfigurationOptions options);
}