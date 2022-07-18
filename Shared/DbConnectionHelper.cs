using System.Reflection;
using DbContextLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Shared
{
    public static class DbConnectionHelper
    {
        private const string SettingsManifestResourceName = "Shared.appsettings.json";

        private const string DbNameString = "Contabilidad"; // TODO: Define database name
        private static IConfigurationRoot? _config;
        private static DbContextOptionsBuilder<ContabilidadDbContext>? _dbContextOptionsBuilder;

        public static DbContextOptions<ContabilidadDbContext> DbContextOptions
        {
            get
            {
                if (_config == null || _dbContextOptionsBuilder == null)
                {
                    CreateConfigurationRoot();
                }

                return _dbContextOptionsBuilder!.Options;
            }
        }

        private static void CreateConfigurationRoot()
        {
            var a = Assembly.GetAssembly(typeof(DbConnectionHelper));
            var stream = a.GetManifestResourceStream(SettingsManifestResourceName);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonStream(stream);


            _config = builder.Build();

            _dbContextOptionsBuilder = new DbContextOptionsBuilder<ContabilidadDbContext>();
            _dbContextOptionsBuilder.UseSqlServer(_config.GetConnectionString(DbNameString));

            // return _dbContextOptionsBuilder.Options;
        }
    }
}