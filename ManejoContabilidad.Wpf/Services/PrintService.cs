using System;
using System.Threading;
using System.Threading.Tasks;
using ExcelModule;
using Shared.Models;

namespace ManejoContabilidad.Wpf.Services;

public class PrintService
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
        _excelWriter.SettingsChanged(e.ExcelConfigurationOptions);
    }


    ~PrintService()
    {
        _settings.ExcelSettingsChanged -= ExcelSettingsChanged;
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
}