using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public class InvoiceService : IInvoiceService
{
    private readonly SemaphoreSlim _semaphore = new(1);

    public async Task<Shared.Models.Invoice?> AddAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();

        await using var db = new InvoiceDb();
        await db.Invoices.AddAsync(invoice);
        await db.SaveChangesAsync();

        _semaphore.Release();

        return invoice;
    }

    public async Task<Shared.Models.Invoice?> DeleteAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();

        await using var db = new InvoiceDb();
        db.Invoices.Remove(invoice);
        await db.SaveChangesAsync();

        _semaphore.Release();

        return invoice;
    }

    public async Task<Shared.Models.Invoice?> EditAsync(Shared.Models.Invoice invoice)
    {
        await _semaphore.WaitAsync();

        await using var db = new InvoiceDb();
        db.Invoices.Update(invoice);
        await db.SaveChangesAsync();

        _semaphore.Release();

        return invoice;
    }

    public async Task<List<Shared.Models.Invoice>> GetAllAsync(int page)
    {
        await _semaphore.WaitAsync();

        await using var db = new InvoiceDb();

        var list = await db.Invoices.OrderBy(i => i.InvoiceNumber).ToListAsync();

        _semaphore.Release();

        return list;
    }
}