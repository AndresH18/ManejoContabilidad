using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Shared;

namespace ManejoContabilidad.Wpf.Services.AppEnvironment;

internal class AppEnvironmentService
{
    public IConfiguration Configuration { get; }

    public AppEnvironmentService()
    {
        Configuration = CreateConfiguration();
    }

    public string? GetConnectionString(string name)
    {
        return Configuration.GetConnectionString(name) ??
               throw new ArgumentNullException($"Connection String for {name} was not found.");
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
        return ConfigureFromStream();
    }

    private static IConfigurationRoot ConfigureFromFile()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        return configuration.Build();
    }

    private static IConfigurationRoot ConfigureFromStream()
    {
        var assembly = Assembly.GetAssembly(typeof(InvoiceDb));
        var stream = assembly?.GetManifestResourceStream(typeof(InvoiceDb), "appsettings.json")
                     ?? throw new FileNotFoundException($"'appsettings.json' file not found in assembly '{assembly?.FullName}'");

        var builder = new ConfigurationBuilder().AddJsonStream(stream);
        return builder.Build();
    }
}