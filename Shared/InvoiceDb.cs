using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Models;

namespace Shared;

public class InvoiceDb : DbContext
{
    private const string DefaultConnectionName = "localdb";

    public InvoiceDb()
    {
        ConnectionString = GetConnectionString();
    }

    public InvoiceDb(string connectionString)
    {
        ConnectionString = connectionString;
    }

    private string ConnectionString { get; }

    public DbSet<Invoice> Invoices { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Invoice>().ToTable(t => t.IsTemporal());
        modelBuilder.Entity<Invoice>().Property(i => i.CreationDate).HasDefaultValueSql("GETDATE()");
    }

    private static string GetConnectionString()
    {
        var assembly = Assembly.GetAssembly(typeof(InvoiceDb))
                       ?? throw new NullReferenceException($"Could not find assembly of {typeof(InvoiceDb)}");
        var stream = assembly.GetManifestResourceStream(typeof(InvoiceDb), "appsettings.json")
                     ?? throw new NullReferenceException(
                         $"'appsettings.json' file not found in assembly '{assembly.FullName}'");

        var builder = new ConfigurationBuilder().AddJsonStream(stream);

        var configuration = builder.Build();
        return configuration.GetConnectionString(DefaultConnectionName)
               ?? throw new ArgumentNullException($"Connection String for '{DefaultConnectionName}' was not found.");
    }
}