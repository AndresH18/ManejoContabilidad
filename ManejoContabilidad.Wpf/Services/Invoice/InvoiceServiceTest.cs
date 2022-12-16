using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public class InvoiceServiceTest : IInvoiceService
{
    public async Task<List<Shared.Models.Invoice>> GetAllAsync()
    {
        await Task.Run(() => Thread.Sleep(2000));

        await using var db = new TestDbContext();

        // return await db.Invoices.Include(i => i.Client).ToListAsync();
        return await db.Invoices.ToListAsync();
    }

    public async Task<Shared.Models.Invoice?> AddAsync(Shared.Models.Invoice invoice)
    {
        // await Task.Run(() => Thread.Sleep(2000));
        await using var db = new TestDbContext();
        await db.Invoices.AddAsync(invoice);
        await db.SaveChangesAsync();
        return invoice;
    }

    public async Task<Shared.Models.Invoice?> DeleteAsync(Shared.Models.Invoice invoice)
    {
        await Task.Run(() => Thread.Sleep(2000));
        await using var db = new TestDbContext();
        db.Invoices.Remove(invoice);
        await db.SaveChangesAsync();
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
}