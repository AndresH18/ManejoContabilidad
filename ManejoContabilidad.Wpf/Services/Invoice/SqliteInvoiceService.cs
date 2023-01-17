using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared;
using InvoiceModel = Shared.Models.Invoice;

namespace ManejoContabilidad.Wpf.Services.Invoice;

public class SqliteInvoiceService : IInvoiceService
{
    private readonly SemaphoreSlim _semaphore = new(1);

    public async Task<ServiceResult<List<InvoiceModel>>> GetAllAsync(int page)
    {
        await _semaphore.WaitAsync();

        var result = new ServiceResult<List<InvoiceModel>>();
        try
        {
            await using var db = new SqliteDbContext();
            result.Value = await db.Invoices.OrderBy(i => i.InvoiceNumber).ToListAsync();
            result.Status = ResultStatus.Ok;
        }
        catch (Exception ex) when
            (ex is OperationCanceledException or DbUpdateException or DbUpdateConcurrencyException or DbException)
        {
            result.Status = ResultStatus.Failed;
        }

        _semaphore.Release();

        return result;
    }

    public async Task<ServiceResult<InvoiceModel>> AddAsync(InvoiceModel invoice)
    {
        await _semaphore.WaitAsync();
        var result = new ServiceResult<InvoiceModel>();

        try
        {
            await using var db = new SqliteDbContext();
            await db.Invoices.AddAsync(invoice);
            await db.SaveChangesAsync();
            result.Status = ResultStatus.Ok;
            result.Value = invoice;
        }
        catch (Exception ex) when (ex is OperationCanceledException or DbUpdateException or DbUpdateConcurrencyException
                                       or DbException)
        {
            result.Status = ResultStatus.Failed;
        }

        _semaphore.Release();
        return result;
    }

    public async Task<ServiceResult<InvoiceModel>> EditAsync(InvoiceModel invoice)
    {
        await _semaphore.WaitAsync();
        var result = new ServiceResult<InvoiceModel>();
        try
        {
            await using var db = new SqliteDbContext();
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

    public async Task<ServiceResult<InvoiceModel>> DeleteAsync(InvoiceModel invoice)
    {
        await _semaphore.WaitAsync();
        var result = new ServiceResult<InvoiceModel>();
        try
        {
            await using var db = new SqliteDbContext();
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
}

internal class SqliteDbContext : DbContext
{
    private const string ConnectionString = "";
    public DbSet<InvoiceModel> Invoices { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
    }
}