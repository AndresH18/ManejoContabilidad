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

    public async Task<ServiceResult> Print(InvoicePrintDto invoicePrintDto, bool preview)
    {
        await _semaphore.WaitAsync();

        var result = new ServiceResult();
        try
        {
            _excelWriter.Write(invoicePrintDto);
            _excelWriter.Print(preview);
            result.Status = ResultStatus.Ok;
        }
        catch (Exception ex)
        {
            result.Status = ResultStatus.Failed;
            result.ErrorMessage = ex.Message;
        }

        _semaphore.Release();

        return result;
    }
}