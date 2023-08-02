// See https://aka.ms/new-console-template for more information

using Shared;

Console.WriteLine("Hello, World!");

// using (var excel = new ExcelWriter())
// {
//     Console.WriteLine("Excel instance created");
//     excel.WriteClient("Andres");
//     excel.WriteDate(DateTime.Today);
//     excel.WriteInvoiceNumber(1234);
//     excel.WritePrice(1_233_988);
//     excel.Print();
// } 

Console.WriteLine("Outside of Scope");
Console.WriteLine(ConsoleApp1.Properties.startsettings.Default.MySetting);