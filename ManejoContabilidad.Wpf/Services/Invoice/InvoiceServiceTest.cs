using System;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public class InvoiceServiceTest : IInvoiceService, IDisposable
{
    // public const int RowsPerPage = 2;

    private readonly SemaphoreSlim _semaphore = new(1);

    public async Task<List<Shared.Models.Invoice>> GetAllAsync(int page)
    {
        await _semaphore.WaitAsync();
        // await Task.Run(() => Thread.Sleep(2000));

        await using var db = new TestDbContext();

        var list = await db.Invoices
            .OrderBy(i => i.InvoiceNumber)
            // .Skip(page * RowsPerPage)
            // .Take(RowsPerPage)
            .ToListAsync();

        _semaphore.Release();

        return list;
    }

    public async Task<Shared.Models.Invoice?> AddAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();

        await Task.Run(() => Thread.Sleep(10000));
        await using var db = new TestDbContext();
        await db.Invoices.AddAsync(invoice);
        await db.SaveChangesAsync();

        _semaphore.Release();

        return invoice;
    }

    public async Task<Shared.Models.Invoice?> DeleteAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();

        await Task.Run(() => Thread.Sleep(2000));

        await using var db = new TestDbContext();
        db.Invoices.Remove(invoice);
        await db.SaveChangesAsync();

        _semaphore.Release();

        return invoice;
    }

    public async Task<Shared.Models.Invoice?> EditAsync(Shared.Models.Invoice invoice)
    {
        // await Task.Run(() => Thread.Sleep(2000));
        /*var index = _invoices.FindIndex(i => i.Id == invoice.Id);
        if (index >= 0)
            _invoices[index] = invoice;*/

        await using var db = new TestDbContext();
        db.Invoices.Update(invoice);
        await db.SaveChangesAsync();

        return invoice;
    }

    public void Dispose()
    {
        _semaphore.Dispose();
    }
}