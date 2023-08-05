using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using Models = Shared.Models;

// ReSharper disable once CheckNamespace
namespace Shared;

public class ExcelWriter : IExcelWriter
{
    private readonly Excel.Application _app;
    private Excel.Workbook _workbook;

    private ExcelConfigurationOptions _options;

    public ExcelWriter(ExcelConfigurationOptions excelConfigurationOptions)
    {
        _options = excelConfigurationOptions;
        try
        {
            _app = new Excel.Application {Visible = true};
            // _app.Workbooks.Open(
            //     Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ExcelTest.xlsx"));
            _workbook = _app.Workbooks.Open(_options.ExcelFile);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }

    ~ExcelWriter() => Dispose();

    public bool IsVisible { get; set; }

    public void Write(Models::InvoicePrintDto invoice)
    {
        WriteClient(invoice.Name);
        WritePrice(invoice.Price);
        WriteInvoiceNumber(invoice.InvoiceNumber);
        WriteDate(invoice.DateTime);
    }


    public void Print(bool preview = true)
    {
        var sheet = (Excel.Worksheet) _workbook.Sheets[ExcelConfigurationOptions.WorkSheetName];
        sheet.PrintOut(1, 1, 1, preview);
    }

    public void ReloadSettings(ExcelConfigurationOptions options)
    {
        _workbook.Close();
        _options = options;
        OpenWorkbook();
    }

    public void Dispose()
    {
        _app.Visible = true;
        _workbook.Close();
        _app.Quit();
        GC.SuppressFinalize(this);
    }

    private void OpenWorkbook()
    {
        _workbook = _app.Workbooks.Open(_options.FileName);
    }

    private void WriteClient(string client)
    {
        var cell = GetClientCell();
        cell.Value = client;
    }

    private void WriteDate(DateTime date)
    {
        var cell = GetDateCell();
        cell.Value = date.ToShortDateString();
    }

    private void WriteInvoiceNumber(int invoiceNumber)
    {
        var cell = GetInvoiceCell();
        cell.Value = invoiceNumber;
    }

    private void WritePrice(double price)
    {
        var cell = GetPriceCell();
        cell.Value = price;
    }


    private Excel.Range GetClientCell()
    {
        var cell = _options.Cells["client"];
        var sheet = GetWorksheet();
        return sheet.Cells[cell.Row, cell.Column];
    }

    private Excel.Range GetInvoiceCell()
    {
        var cell = _options.Cells["invoice"];
        var sheet = GetWorksheet();
        return sheet.Cells[cell.Row, cell.Column];
    }

    private Excel.Range GetDateCell()
    {
        var cell = _options.Cells["date"];
        var sheet = GetWorksheet();
        return sheet.Cells[cell.Row, cell.Column];
    }

    private Excel.Range GetPriceCell()
    {
        var cell = _options.Cells["price"];
        var sheet = GetWorksheet();
        return sheet.Cells[cell.Row, cell.Column];
    }

    private Excel.Worksheet GetWorksheet()
    {
        return _workbook.Sheets[ExcelConfigurationOptions.WorkSheetName];
    }

    private void Check()
    {
        foreach (Excel.Workbook workbook in _app.Workbooks)
        {
            Console.WriteLine(workbook.Name);
        }
    }
}