using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DbContextLibrary
{
    public class ContabilidadDbContext : DbContext
    {
        private const string DbName = "DatabaseName"; // TODO: Define database name
        
        private static IConfigurationRoot? _configuration;
        private static DbContextOptionsBuilder<ContabilidadDbContext>? _dbContextOptionsBuilder;


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
            base.OnModelCreating(modelBuilder);
        }


        private void CreateConfigurationRoot()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();

            _dbContextOptionsBuilder = new DbContextOptionsBuilder<ContabilidadDbContext>();
            _dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString(DbName));
        }
    }
}