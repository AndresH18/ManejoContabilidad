﻿using Models = Shared.Models;

namespace ExcelModule;

public interface IExcelWriter
{
    public void Write(Models::Invoice invoice);
    public void WriteClient(string client);
    public void WriteDate(DateTime date);
    public void WritePrice(double price);
    public void WriteInvoiceNumber(int invoiceNumber);
    public void Print();
}