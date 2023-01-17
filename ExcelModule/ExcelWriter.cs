using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelModule;

public class ExcelWriter : IExcelWriter, IDisposable
{
    private readonly Excel.Application _app;

    public required ExcelData ExcelData { get; init; }

    public ExcelWriter()
    {
        _app = new Excel.Application { Visible = true };
        _app.Workbooks.Open(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ExcelTest.xlsx"));
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
        var sheet = (Excel.Worksheet)_app.Workbooks[ExcelData.WorkbookName].Sheets[ExcelData.WorksheetName];
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
        var c = ExcelData.Cells.Client;
        var sheet = GetWorksheet();
        return sheet.Cells[c.Row, c.Column];
    }

    private Excel.Range GetInvoiceCell()
    {
        var i = ExcelData.Cells.Invoice;
        var sheet = GetWorksheet();
        return sheet.Cells[i.Row, i.Column];
    }

    private Excel.Range GetDateCell()
    {
        var d = ExcelData.Cells.Date;
        var sheet = GetWorksheet();
        return sheet.Cells[d.Row, d.Column];
    }

    private Excel.Range GetPriceCell()
    {
        var p = ExcelData.Cells.Price;
        var sheet = GetWorksheet();
        return sheet.Cells[p.Row, p.Column];
    }

    private Excel.Worksheet GetWorksheet()
    {
        return _app.Workbooks[ExcelData.WorkbookName].Sheets[ExcelData.WorksheetName];
    }

    private void Check()
    {
        foreach (Excel.Workbook workbook in _app.Workbooks)
        {
            Console.WriteLine(workbook.Name);
        }
    }
}