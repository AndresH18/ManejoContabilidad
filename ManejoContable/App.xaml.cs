using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DbContextLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared;

namespace ManejoContable
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // private const string DbNameString = "SomeName"; 
        // private static IConfigurationRoot? _config;
        // private static DbContextOptionsBuilder<ContabilidadDbContext>? _dbContextOptionsBuilder;

        public static DbContextOptions<ContabilidadDbContext> DbOptions => DbConnectionHelper.DbContextOptions;
        // {
        //     get
        //     {
        //         if (_config == null || _dbContextOptionsBuilder == null)
        //         {
        //             CreateConfigurationRoot();
        //         }
        //
        //         return _dbContextOptionsBuilder!.Options;
        //     }
        // }

        public App()
        {
            //     CreateConfigurationRoot();
        }

        // private static void CreateConfigurationRoot()
        // {
        //     
        //
        //     var builder = new ConfigurationBuilder()
        //         .SetBasePath(Directory.GetCurrentDirectory())
        //         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //     _config = builder.Build();
        //
        //     _dbContextOptionsBuilder = new DbContextOptionsBuilder<ContabilidadDbContext>();
        //     _dbContextOptionsBuilder.UseSqlServer(_config.GetConnectionString(DbNameString));
        //
        //     // return _dbContextOptionsBuilder.Options;
        // }
    }
}