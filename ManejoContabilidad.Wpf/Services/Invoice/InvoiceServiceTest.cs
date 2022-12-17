using Microsoft.EntityFrameworkCore;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public class InvoiceServiceTest : IInvoiceService
{
    // public const int RowsPerPage = 2;

    public async Task<List<Shared.Models.Invoice>> GetAllAsync(int page)
    {
        // await Task.Run(() => Thread.Sleep(2000));

        await using var db = new TestDbContext();

        return await db.Invoices
            .OrderBy(i => i.InvoiceNumber)
            // .Skip(page * RowsPerPage)
            // .Take(RowsPerPage)
            .ToListAsync();
    }

    public async Task<Shared.Models.Invoice?> AddAsync(Shared.Models.Invoice invoice)
    {
        await Task.Run(() => Thread.Sleep(5000));
        await using var db = new TestDbContext();
        await db.Invoices.AddAsync(invoice);
        await db.SaveChangesAsync();
        return invoice;
    }

    public async Task<Shared.Models.Invoice?> DeleteAsync(Shared.Models.Invoice invoice)
    {
        // await Task.Run(() => Thread.Sleep(2000));
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