using System;
using System.IO;
using System.Reflection;
using ExcelModule;
using Microsoft.Extensions.Configuration;

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
        return Configuration.GetConnectionString(name);
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
    // ReSharper disable once UnusedMember.Local
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