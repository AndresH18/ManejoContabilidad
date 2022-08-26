using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ManejoContable
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region DbContextOptionsBuilder

        // private const string DbNameString = "Contabilidad";

        // private static readonly string SettingsManifestResourceName = "ManejoContable.appsettings.json";

        // private static IConfigurationRoot? _config;

        // private static DbContextOptionsBuilder<ContabilidadDbContext>? _dbContextOptionsBuilder;

        // public static DbContextOptions<ContabilidadDbContext> DbOptions
        // {
        //     get
        //     {
        //         if (_config == null || _dbContextOptionsBuilder == null)
        //         {
        //             CreateConfigurationRoot();
        //         }

        //         return _dbContextOptionsBuilder!.Options;
        //     }
        // }


        // private static void CreateConfigurationRoot()
        // {
        //     var assembly = Assembly.GetAssembly(typeof(App));
        //     var stream = assembly?.GetManifestResourceStream(SettingsManifestResourceName);

        //     var builder = new ConfigurationBuilder()
        //         .SetBasePath(Directory.GetCurrentDirectory())
        //         .AddJsonStream(stream);

        //     _config = builder.Build();

        //     _dbContextOptionsBuilder = new DbContextOptionsBuilder<ContabilidadDbContext>();
        //     _dbContextOptionsBuilder.UseSqlServer(_config.GetConnectionString(DbNameString));

        //     /*
        //     var builder = new ConfigurationBuilder()
        //         .SetBasePath(Directory.GetCurrentDirectory())
        //         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //     _config = builder.Build();

        //     _dbContextOptionsBuilder = new DbContextOptionsBuilder<ContabilidadDbContext>();
        //     _dbContextOptionsBuilder.UseSqlServer(_config.GetConnectionString(DbNameString));
        //     */

        //     // return _dbContextOptionsBuilder.Options;
        // }
        // public App()
        // {
        //     CreateConfigurationRoot();
        // }

        #endregion

        public App()
        {
        }
    }
}