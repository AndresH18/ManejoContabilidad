using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public class InvoiceService : IInvoiceService
{
    private readonly SemaphoreSlim _semaphore = new(1);

    public async Task<ServiceResult<Shared.Models.Invoice>> AddAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();
        var result = new ServiceResult<Shared.Models.Invoice>();
        try
        {
            await using var db = new InvoiceDb();
            await db.Invoices.AddAsync(invoice);
            await db.SaveChangesAsync();
            result.Value = invoice;
            result.Status = ResultStatus.Ok;
        }
        catch (Exception ex) when
            (ex is OperationCanceledException or DbUpdateException or DbUpdateConcurrencyException or DbException)
        {
            result.Status = ResultStatus.Failed;
            result.ErrorMessage = ex.Message;
        }

        _semaphore.Release();

        return result;
    }

    public async Task<ServiceResult<Shared.Models.Invoice>> DeleteAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();
        var result = new ServiceResult<Shared.Models.Invoice>();
        try
        {
            await using var db = new InvoiceDb();
            db.Invoices.Remove(invoice);
            await db.SaveChangesAsync();
            result.Value = invoice;
            result.Status = ResultStatus.Ok;
        }
        catch (Exception ex) when
            (ex is OperationCanceledException or DbUpdateException or DbUpdateConcurrencyException or DbException)
        {
            result.Status = ResultStatus.Failed;
            result.ErrorMessage = ex.Message;
        }

        _semaphore.Release();

        return result;
    }

    public async Task<ServiceResult<Shared.Models.Invoice>> EditAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();
        var result = new ServiceResult<Shared.Models.Invoice>();
        try
        {
            await using var db = new InvoiceDb();
            db.Invoices.Update(invoice);
            await db.SaveChangesAsync();
            result.Value = invoice;
            result.Status = ResultStatus.Ok;
        }
        catch (Exception ex) when
            (ex is OperationCanceledException or DbUpdateException or DbUpdateConcurrencyException or DbException)
        {
            result.Status = ResultStatus.Failed;
            result.ErrorMessage = ex.Message;
        }

        _semaphore.Release();

        return result;
    }

    public async Task<ServiceResult<List<Shared.Models.Invoice>>> GetAllAsync(int page)
    {
        await _semaphore.WaitAsync();
        var result = new ServiceResult<List<Shared.Models.Invoice>>();
        try
        {
            await using var db = new InvoiceDb();

            result.Value = await db.Invoices.OrderBy(i => i.InvoiceNumber).ToListAsync();
            result.Status = ResultStatus.Ok;
        }
        catch (Exception ex) when
            (ex is OperationCanceledException or ArgumentNullException or DbException)
        {
            result.Status = ResultStatus.Failed;
            result.ErrorMessage = ex.Message;
        }

        _semaphore.Release();

        return result;
    }
}