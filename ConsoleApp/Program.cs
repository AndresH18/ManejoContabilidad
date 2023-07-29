// See https://aka.ms/new-console-template for more information

using System.Reflection;
using ConsoleApp1.Recognizer;
using Microsoft.Extensions.Configuration;


IConfiguration CreateConfiguration(Type assemblyType)
{
    Assembly assembly = assemblyType.Assembly;

    assembly.GetManifestResourceNames().ToList().ForEach(s => Console.WriteLine($"Resource: {s}"));

    var configurationStream = assembly.GetManifestResourceStream("ConsoleApp1.appsettings.json")
                              ?? throw new FileNotFoundException(
                                  $"'appsettings.json' not found in assembly {assembly.FullName}");
    
    var configuration = new ConfigurationBuilder().AddJsonStream(configurationStream);

    // var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    //     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    return configuration.Build();
}


var configuration = CreateConfiguration(typeof(RecognizerService));
var section = configuration.GetSection(nameof(RecognizerConfiguration));
var recognizerConfiguration = section.Get<RecognizerConfiguration>()!;

var recognizer = new RecognizerService(recognizerConfiguration);
var fileStream = File.OpenRead(@"C:\Users\andre\source\repos\ManejoContable-Docs\Comodin SAS  # 1312  OC 4500023987.pdf");

// Console.WriteLine(await recognizer.Get(fileStream, "client-name"));

await recognizer.GetTable(fileStream);
