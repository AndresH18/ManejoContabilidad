// See https://aka.ms/new-console-template for more information


using DbContextLibrary;
using ModelEntities;

Console.WriteLine("Hello, World!");

using (var db = new ContabilidadDbContext())
{
    db.Clientes.Add(new Cliente() {Nombre = "Andres", TipoDocumento = TipoDocumento.Ti, NumeroDocumento = "EEEEEEE"});
    Console.WriteLine("Saving Changes");
    db.SaveChanges();
    Console.WriteLine("Changes Saved");

    db.Clientes.ToList()
        .ForEach(c => Console.WriteLine("id={0}; nombre={1}, tipoDoc={2}", c.Id, c.Nombre, c.TipoDocumento));
    db.Clientes.RemoveRange(db.Clientes.ToList());
    db.SaveChanges();
}

Console.WriteLine();

#region Probando Leer los Ensamblados

// Console.WriteLine(DbConnectionHelper.DbContextOptions.ToString());
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

// var a = Assembly.GetAssembly(typeof(App))

#endregion