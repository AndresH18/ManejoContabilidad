using System.Reflection;
using DbContextLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Shared
{
    public static class DbConnectionHelper
    {
        #region DEBUG REGION CONFIGURATION

        private const bool USE_EMBEDDED = true;
        private const string MANIFEST_RESOURCE_NAME = "Shared.appsettings.json";

        #endregion

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
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

            if (USE_EMBEDDED)
            {
                var a = Assembly.GetAssembly(typeof(DbConnectionHelper));
                var stream = a.GetManifestResourceStream(MANIFEST_RESOURCE_NAME);

                builder.AddJsonStream(stream);
            }
            else
            {
                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            }

            _config = builder.Build();

            _dbContextOptionsBuilder = new DbContextOptionsBuilder<ContabilidadDbContext>();
            _dbContextOptionsBuilder.UseSqlServer(_config.GetConnectionString(DbNameString));

            // return _dbContextOptionsBuilder.Options;
        }
    }
}