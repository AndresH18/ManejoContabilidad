// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Microsoft.Extensions.Configuration;
using Shared;




Console.WriteLine("Hello, World!");
Console.WriteLine(DbConnectionHelper.DbContextOptions.ToString());
//
// // ReadFromEmbeddedResources();
//
// ReadFromEmbeddedResources();
// var a = Assembly.GetAssembly(typeof(DbConnectionHelper));
// var stream = a.GetManifestResourceStream("Shared.appsettings.json");
// var directory = Directory.GetCurrentDirectory();
//
// var s = new ConfigurationBuilder().SetBasePath(directory).AddJsonStream(stream).Build()
//     .GetConnectionString("Contabilidad");
// Console.WriteLine(s);
//
// var builder = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
//
// Console.WriteLine(builder.Build().GetConnectionString("Contabilidad"));
//
// static void ReadFromEmbeddedResources()
// {
//     var a = Assembly.GetAssembly(typeof(DbConnectionHelper))?.GetManifestResourceNames() ?? Array.Empty<string>();
//
//     foreach (var s in a)
//     {
//         Console.WriteLine(s);
//         using var stream = Assembly.GetAssembly(typeof(DbConnectionHelper))?.GetManifestResourceStream(s);
//
//         using var reader = new StreamReader(stream);
//
//         Console.WriteLine(reader.ReadToEnd());
//     }
// }