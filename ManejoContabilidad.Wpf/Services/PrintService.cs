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

    public PrintService(IExcelWriter excelWriter)
    {
        _excelWriter = excelWriter;
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