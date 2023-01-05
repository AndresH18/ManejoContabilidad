using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared;

public class TestDbContext : DbContext
{
    private const string TestDbDirectory = "../../..";
    private const string TestDbName = "contab.db";
    private const string TestConnectionString = $"Data Source={TestDbDirectory}/{TestDbName}";

    // public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;

    public static async void EnsureDatabaseCreated()
    {
        var db = new TestDbContext();
        if (await db.Database.EnsureCreatedAsync())
        {
            await InitializeTestDataAsync(db);
        }
    }

    private static async Task InitializeTestDataAsync(TestDbContext db)
    {
        /*await db.Clients.AddRangeAsync(new Client
            {
                Id = 1,
                Name = "Andres",
                Document = "1",
                Email = "andres@email.com"
            },
            new Client
            {
                Id = 2,
                Name = "David",
                Document = "2",
                Email = "david@email.com"
            });*/

        await db.Invoices.AddRangeAsync(new Invoice {Id = 1, ClientName = "Andres", InvoiceNumber = 2},
            new Invoice
            {
                Id = 2,
                ClientName = "Andres",
                Path = @"C:\Users\andre\Desktop\Blazor-for-ASP-NET-Web-Forms-Developers.pdf",
                InvoiceNumber = 344,
                Price = 123_676
            },
            new Invoice {Id = 3, ClientName = "David", InvoiceNumber = 1_234_567, Price = 93_451_222},
            new Invoice {Id = 4, ClientName = "Juan Manuel", InvoiceNumber = 9856});

        await db.SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(TestConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // uri 
        // modelBuilder.Entity<Invoice>(i => i.Property(p => p.Path).HasConversion<UriToStringConverter>());
    }
}