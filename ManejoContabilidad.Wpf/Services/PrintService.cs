using System;
using System.Threading;
using System.Threading.Tasks;
using Shared;
using Shared.Models;

namespace ManejoContabilidad.Wpf.Services;

public class PrintService : IDisposable
{
    private readonly SemaphoreSlim _semaphore = new(1);
    private readonly IExcelWriter _excelWriter;
    private readonly SettingsManager _settings;

    public PrintService(IExcelWriter excelWriter, SettingsManager settings)
    {
        _excelWriter = excelWriter;
        _settings = settings;
        _settings.ExcelSettingsChanged += ExcelSettingsChanged;
    }

    private void ExcelSettingsChanged(object? sender, ExcelSettingsChangedEventArgs e)
    {
        _excelWriter.ReloadSettings(e.ExcelConfigurationOptions);
    }


    ~PrintService()
    {
        Dispose(false);
    }


    public async Task<Result<bool, Exception>> Print(InvoicePrintDto invoicePrintDto, bool preview)
    {
        await _semaphore.WaitAsync();

        try
        {
            _excelWriter.Write(invoicePrintDto);
            _excelWriter.Print(preview);

            _semaphore.Release();

            return true;
        }
        catch (Exception ex)
        {
            _semaphore.Release();

            return ex;
        }
    }

    private void ReleaseUnmanagedResources()
    {
        _excelWriter.Dispose();
    }

    private void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing)
        {
            _semaphore.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}