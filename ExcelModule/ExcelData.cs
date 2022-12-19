namespace ExcelModule;

public class ExcelData
{
    public string WorkbookName { get; set; }
    public string WorksheetName { get; set; }
    public Cells Cells { get; set; }
}

public class Cells
{
    public Client Client { get; set; }
    public Invoice Invoice { get; set; }
    public Date Date { get; set; }
    public Price Price { get; set; }
}

public class Client
{
    public int Row { get; set; }
    public string Column { get; set; }
}

public class Invoice
{
    public int Row { get; set; }
    public string Column { get; set; }
}

public class Date
{
    public int Row { get; set; }
    public string Column { get; set; }
}

public class Price
{
    public int Row { get; set; }
    public string Column { get; set; }
}