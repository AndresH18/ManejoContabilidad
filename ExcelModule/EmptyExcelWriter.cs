namespace ExcelModule;

public class EmptyExcelWriter : IExcelWriter
{
    public void Print(bool preview = true)
    {
        Thread.Sleep(5000);
    }

    public void Write(Shared.Models.InvoicePrintDto invoice)
    {
        
    }

    public void WriteClient(string client)
    {
        
    }

    public void WriteDate(DateTime date)
    {
        
    }

    public void WriteInvoiceNumber(int invoiceNumber)
    {
        
    }

    public void WritePrice(double price)
    {
        
    }
}