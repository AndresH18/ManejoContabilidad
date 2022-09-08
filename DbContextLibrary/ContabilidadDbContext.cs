using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using ModelEntities;

namespace DbContextLibrary;

public class ContabilidadDbContext : DbContext
{
    private const string DbName = "Contabilidad"; // TODO: Define database name

    private static IConfigurationRoot? _configuration;

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<InfoFactura> InfoFactura { get; set; }
    public DbSet<DetallesFactura> DetallesFactura { get; set; }

    public ContabilidadDbContext()
    {
    }

    public ContabilidadDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            var a = Assembly.GetAssembly(typeof(ContabilidadDbContext));
            var stream = a?.GetManifestResourceStream("DbContextLibrary.appsettings.json");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (stream != null)
                builder.AddJsonStream(stream);

            _configuration = builder.Build();

            var connectionString = _configuration.GetConnectionString(DbName);

            if (connectionString != null)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
            .Property(c => c.TipoDocumento)
            .HasConversion<EnumToStringConverter<TipoDocumento>>();

        modelBuilder.Entity<Cliente>().HasData(
            new Cliente
            {
                Id = 1, Nombre = "Imporcom", NumeroDocumento = "123-456-7890", TipoDocumento = TipoDocumento.Nit
            },
            new Cliente
            {
                Id = 2, Nombre = "Andres' Programmers SAS", NumeroDocumento = "111-222-33-44"
            }
        );

        modelBuilder.Entity<DetallesFactura>()
            .HasKey(df => new {df.FacturaId, df.ProductoId});
    }


    // private void CreateConfigurationRoot()
    // {
    //     var builder = new ConfigurationBuilder()
    //         .SetBasePath(Directory.GetCurrentDirectory())
    //         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    //     _configuration = builder.Build();
    //
    //     _dbContextOptionsBuilder = new DbContextOptionsBuilder<ContabilidadDbContext>();
    //     _dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString(DbName));
    // }

    public static ContabilidadDbContext InMemoryDatabase()
    {
        var contextOptions = new DbContextOptionsBuilder<ContabilidadDbContext>()
            .UseInMemoryDatabase("ContabilidadDbTesting")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        var db = new ContabilidadDbContext(contextOptions);

        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        db.Categorias.AddRange(
            new Categoria {Name = "Televisores"},
            new Categoria {Name = "Radios"}
        );

        db.Marcas.AddRange(
            new Marca {Name = "Samsung", Description = "Korean Company"},
            new Marca {Name = "Nokia", Description = "Indestructible Phones"});

        db.Productos.AddRange(
            new Producto
            {
                Nombre = "Radio Nokia",
                Codigo = "rad-01",
                CategoriaId = 2,
                MarcaId = 2,
                PrecioUnitario = 20.3M
            },
            new Producto
            {
                Nombre = "Televisor Samsung 70'",
                Codigo = "tel-01-70",
                CategoriaId = 1,
                MarcaId = 1,
                PrecioUnitario = 50M
            });


        db.SaveChanges();
        return db;
    }
}