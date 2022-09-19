// See https://aka.ms/new-console-template for more information

using RecognizerLibrary;

Console.WriteLine("Hello, World!");

#error Set the apikey and endpoint for the form recognizer
var service = new InvoiceService(
    apiKey: "<apikey>",
    endPoint: @"<endpoint>") {ModelId = "contab-model-2"};

#error Check that file exist
var fileStream = File.OpenRead(
    @"\ManejoContable Docs\Gravas y Arenas del Cauca SAS  # 1486.pdf");


Console.WriteLine("Preparing to analize file");

await service.AnalyzeDocumentFromStream(fileStream);


#region Type Testing

void TypeTesting()
{
    Persona p = new Persona();
    Estudiante e = new Estudiante();

    Persona pe = new Estudiante();

    Console.WriteLine(p.GetType() == typeof(Persona));
    Console.WriteLine(e.GetType() == typeof(Estudiante));
    Console.WriteLine(pe.GetType().IsAssignableFrom(typeof(Persona)));
    Console.WriteLine(pe.GetType().IsAssignableTo(typeof(Persona)));
    Console.WriteLine(pe.GetType() == typeof(Estudiante));
}

class Persona
{
}

class Estudiante :
    Persona
{
}

#endregion