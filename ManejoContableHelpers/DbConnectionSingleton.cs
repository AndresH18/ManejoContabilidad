using DbContextLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ManejoContableHelpers
{
    public sealed class DBConnectionSingleton
    {
        // We now have lock object that will be used to to synchronize threads
        // during first access to the Singleton
        private static readonly object _lock = new();

        // Instance
        private static volatile DBConnectionSingleton? _instance;

        public static DBConnectionSingleton Instance
        {
            get
            {
                // The comments were taken out from https://refactoring.guru/design-patterns/singleton/csharp/example#example-1

                // This conditional is needed to prevent threads stumbling over the
                // lock once the instance is ready
                if (_instance != null) return _instance;
                // Now, imagine that the program has just been launched. Since
                // there's no Singleton instance yet, multiple threads can
                // simultaneously pass the previous conditional and reach this
                // point almost at the same time. The first of them will acquire
                // lock and will proceed further, while the rest will wait here.
                lock (_lock)
                {
                    // The first thread to acquire the lock, reaches this
                    // conditional, goes inside and creates the Singleton
                    // instance. Once it leaves the lock block, a thread that
                    // might have been waiting for the lock release may then
                    // enter this section. But since the Singleton field is
                    // already initialized, the thread won't create a new
                    // object.
                    if (_instance == null)
                    {
                        _instance = new DBConnectionSingleton();
                    }
                }

                return _instance;
            }
        }

        private const string DbNameString = "SomeName"; // TODO: Define database name

        private IConfigurationRoot? _config;
        private DbContextOptionsBuilder<ContabilidadDbContext>? _dbContextOptionsBuilder;

        public DbContextOptions<ContabilidadDbContext> DbContextOptions
        {
            get
            {
                if (_config == null || _dbContextOptionsBuilder == null)
                {
                    CreateConfigurationRoot();
                }

                return _dbContextOptionsBuilder!.Options; // ! Expression will not be null
            }
        }

        private void CreateConfigurationRoot()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _config = builder.Build();

            _dbContextOptionsBuilder = new DbContextOptionsBuilder<ContabilidadDbContext>();
            _dbContextOptionsBuilder.UseSqlServer(_config.GetConnectionString(DbNameString));
        }


        private DBConnectionSingleton()
        {
            CreateConfigurationRoot();
        }
    }
}