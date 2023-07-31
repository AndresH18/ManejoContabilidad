using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared;
using ManejoContabilidad.Wpf.Properties;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public class InvoiceService : IInvoiceService
{
    private readonly SemaphoreSlim _semaphore = new(1);


    public async Task<Result<Shared.Models.Invoice, Exception>> AddAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();
        try
        {
            await using var db = new InvoiceDb(Settings.Default.InvoiceDb);
            await db.Invoices.AddAsync(invoice);
            await db.SaveChangesAsync();
            _semaphore.Release();
            return invoice;
        }
        catch (Exception ex) when
            (ex is OperationCanceledException or DbUpdateException or DbUpdateConcurrencyException or DbException)
        {
            _semaphore.Release();
            return ex;
        }
    }

    public async Task<Result<Shared.Models.Invoice, Exception>> DeleteAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();
        try
        {
            await using var db = new InvoiceDb(Settings.Default.InvoiceDb);
            db.Invoices.Remove(invoice);
            await db.SaveChangesAsync();
            _semaphore.Release();
            return invoice;
        }
        catch (Exception ex) when
            (ex is OperationCanceledException or DbUpdateException or DbUpdateConcurrencyException or DbException)
        {
            _semaphore.Release();
            return ex;
        }
    }

    public async Task<Result<Shared.Models.Invoice, Exception>> EditAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();
        try
        {
            await using var db = new InvoiceDb(Settings.Default.InvoiceDb);
            db.Invoices.Update(invoice);
            await db.SaveChangesAsync();
            _semaphore.Release();
            return invoice;
        }
        catch (Exception ex) when
            (ex is OperationCanceledException or DbUpdateException or DbUpdateConcurrencyException or DbException)
        {
            _semaphore.Release();
            return ex;
        }
    }

    public async Task<Result<List<Shared.Models.Invoice>, Exception>> GetAllAsync(int page)
    {
        await _semaphore.WaitAsync();
        try
        {
            await using var db = new InvoiceDb(Settings.Default.InvoiceDb);
            var list = await db.Invoices.OrderBy(i => i.InvoiceNumber).ToListAsync();
            _semaphore.Release();
            return list;
        }
        catch (Exception ex) when
            (ex is OperationCanceledException or ArgumentNullException or DbException)
        {
            _semaphore.Release();
            return ex;
        }
    }
}