namespace Shared;

public class EmptyExcelWriter : IExcelWriter
{
    public bool IsVisible { get; set; }

    public void Print(bool preview = true)
    {
        Thread.Sleep(5000);
    }

    public void Write(Shared.Models.InvoicePrintDto invoice)
    {
    }

    public void ReloadSettings(ExcelConfigurationOptions options)
    {
    }

    public void Dispose()
    {
    }
}