﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using ModelEntities;

namespace DbContextLibrary
{
    public class ContabilidadDbContext : DbContext
    {
        private const string DbName = "Contabilidad"; // TODO: Define database name
        
        private static IConfigurationRoot? _configuration;

        public DbSet<Cliente> Clientes { get; set; }

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
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

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

    }
}