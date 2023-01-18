using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared;

public class InvoiceDb : DbContext
{
    private const string ConnectionString =
        "Data Source=localhost; Initial Catalog=InvoiceManagement; TrustServerCertificate=true; Trusted_Connection=true";

    private readonly string _connectionString;

    public InvoiceDb(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<Invoice> Invoices { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Invoice>().ToTable(t => t.IsTemporal());
        modelBuilder.Entity<Invoice>().Property(i => i.CreationDate).HasDefaultValueSql("GETDATE()");
    }
}