using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelModule;

public class ExcelWriter : IExcelWriter, IDisposable
{
    private readonly Excel.Application _app;

    private readonly ExcelData _excelData;

    public ExcelWriter(ExcelData excelData)
    {
        _excelData = excelData;
        try
        {
            _app = new Excel.Application { Visible = true };
            // _app.Workbooks.Open(
            //     Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ExcelTest.xlsx"));
            _app.Workbooks.Open(Path.Combine(_excelData.FileDirectory, _excelData.WorkbookName));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }

    ~ExcelWriter() => Dispose();

    public void Write(Shared.Models.InvoicePrintDto invoice)
    {
        WriteClient(invoice.Name);
        WritePrice(invoice.Price);
        WriteInvoiceNumber(invoice.InvoiceNumber);
        WriteDate(invoice.DateTime);
    }

    public void WriteClient(string client)
    {
        var cell = GetClientCell();
        cell.Value = client;
    }

    public void WriteDate(DateTime date)
    {
        var cell = GetDateCell();
        cell.Value = date.ToShortDateString();
    }

    public void WriteInvoiceNumber(int invoiceNumber)
    {
        var cell = GetInvoiceCell();
        cell.Value = invoiceNumber;
    }

    public void WritePrice(double price)
    {
        var cell = GetPriceCell();
        cell.Value = price;
    }

    public void Print(bool preview = true)
    {
        var sheet = (Excel.Worksheet)_app.Workbooks[_excelData.WorkbookName].Sheets[_excelData.WorksheetName];
        sheet.PrintOut(1, 1, 1, preview);
    }


    public void Dispose()
    {
        _app.Visible = true;
        _app.Quit();
        GC.SuppressFinalize(this);
    }

    private Excel.Range GetClientCell()
    {
        var c = _excelData.Cells.Client;
        var sheet = GetWorksheet();
        return sheet.Cells[c.Row, c.Column];
    }

    private Excel.Range GetInvoiceCell()
    {
        var i = _excelData.Cells.Invoice;
        var sheet = GetWorksheet();
        return sheet.Cells[i.Row, i.Column];
    }

    private Excel.Range GetDateCell()
    {
        var d = _excelData.Cells.Date;
        var sheet = GetWorksheet();
        return sheet.Cells[d.Row, d.Column];
    }

    private Excel.Range GetPriceCell()
    {
        var p = _excelData.Cells.Price;
        var sheet = GetWorksheet();
        return sheet.Cells[p.Row, p.Column];
    }

    private Excel.Worksheet GetWorksheet()
    {
        return _app.Workbooks[_excelData.WorkbookName].Sheets[_excelData.WorksheetName];
    }

    private void Check()
    {
        foreach (Excel.Workbook workbook in _app.Workbooks)
        {
            Console.WriteLine(workbook.Name);
        }
    }
}