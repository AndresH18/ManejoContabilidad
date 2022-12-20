using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExcelModule;
using ManejoContabilidad.Wpf.Services.Invoice;
using ManejoContabilidad.Wpf.Services.Navigation;
using ManejoContabilidad.Wpf.Services.RequestProvider;
using Microsoft.Extensions.Configuration;

namespace ManejoContabilidad.Wpf.Services.AppEnvironment;

internal class AppEnvironmentService
{
    public IConfiguration Configuration { get; private set; }

    public AppEnvironmentService()
    {
        Configuration = CreateConfiguration();
    }

    public string GetHostString()
    {
        var section = Configuration.GetRequiredSection("AppHost:uri");
        return section.Value!;
    }

    public ExcelData GetExcelData()
    {
        var section = Configuration.GetRequiredSection("ExcelData");

        var excelData = new ExcelData();
        section.Bind(excelData);
        return excelData;
    }

    private static IConfiguration CreateConfiguration()
    {
        return ConfigureFromFile();
    }

    private static IConfigurationRoot ConfigureFromFile()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        return configuration.Build();
    }

    [Obsolete]
    private static IConfigurationRoot ConfigureFromStream()
    {
        var assembly = Assembly.GetAssembly(typeof(App));
        var stream = assembly?.GetManifestResourceStream(typeof(App), "appsettings.json");

        if (stream is null)
        {
            throw new FileNotFoundException("'appsettings.json' file not found in assembly");
        }

        var builder = new ConfigurationBuilder().AddJsonStream(stream);
        return builder.Build();
    }
}